using DM.Application.Events.EstoqueSangue;
using DM.Domain.Enums;
using DM.Infrastructure.Data.CommandsDb;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace DM.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IEmailService _emailService;
        private readonly DoeMaisDbContextMySql _dbContext;
        public RelatorioService(IEmailService emailService, DoeMaisDbContextMySql dbContext)
        {
            _emailService = emailService;
            _dbContext = dbContext;
        }
        public async Task<bool> GerarRelatorioEstoqueSangue(string email)
        {
            var eventosEstoqueSangueContent = await _dbContext.OutBoxMessages.Where(e => e.Type.Equals("EstoqueSangueAtualizadoEvent")
                )
                    .Select(x => x.Content)
                    .ToListAsync();

            var estoqueSangueObjects = eventosEstoqueSangueContent.Select(x =>
            {
                var estoqueSangueObject = JsonConvert.DeserializeObject<EstoqueSangueAtualizadoEvent>(x);

                return estoqueSangueObject;
            }).ToList();

            PdfDocument document = new ();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            gfx.DrawString("Relatório", font, XBrushes.Black,
                new XRect(0, 20, page.Width, page.Height),
                new XStringFormat
                {
                    Alignment = XStringAlignment.Center,
                });

            int height = 50;

            var listaTipos = new List<TipoSanguineo>();

            foreach (var estoque in estoqueSangueObjects)
            {

                if (!listaTipos.Contains(estoque.TipoSanguineo))
                {
                    height += 40;

                    switch (estoque.TipoSanguineo)
                    {
                        case Domain.Enums.TipoSanguineo.O:
                            height = GerarEstruturaPorTipo(estoque.TipoSanguineo, estoqueSangueObjects.Where(x => x.TipoSanguineo == TipoSanguineo.O).ToList(), gfx, page, height);
                            listaTipos.Add(TipoSanguineo.O);
                            break;
                        case Domain.Enums.TipoSanguineo.A:
                            height = GerarEstruturaPorTipo(estoque.TipoSanguineo, estoqueSangueObjects.Where(x => x.TipoSanguineo == TipoSanguineo.A).ToList(), gfx, page, height);
                            listaTipos.Add(TipoSanguineo.A);
                            break;
                        case Domain.Enums.TipoSanguineo.B:
                            height = GerarEstruturaPorTipo(estoque.TipoSanguineo, estoqueSangueObjects.Where(x => x.TipoSanguineo == TipoSanguineo.B).ToList(), gfx, page, height);
                            listaTipos.Add(TipoSanguineo.B);
                            break;
                        case Domain.Enums.TipoSanguineo.AB:
                            height = GerarEstruturaPorTipo(estoque.TipoSanguineo, estoqueSangueObjects.Where(x => x.TipoSanguineo == TipoSanguineo.AB).ToList(), gfx, page, height);
                            listaTipos.Add(TipoSanguineo.AB);
                            break;
                        default:
                            break;
                    }
                }
            }


            document.Save($"Pdfs/{email}-relatorio.pdf");

            string caminhoDoPDF = Path.Combine($"../DM.Api/Pdfs/{email}-relatorio.pdf");

            return await _emailService.EnviarEmail(email, caminhoDoPDF);
        }

        private int GerarEstruturaPorTipo(TipoSanguineo tipoSanguineo, List<EstoqueSangueAtualizadoEvent> estoqueSangues, XGraphics gfx, PdfPage page, int heightPage)
        {
            int heightPdf = heightPage;

            gfx.DrawString(
            $"Tipo sanguineo {tipoSanguineo}", new XFont("Verdana", 12, XFontStyle.BoldItalic), XBrushes.Black,
                 new XRect(20, heightPdf, page.Width, page.Height),
                 new XStringFormat()
                 {
                     LineAlignment = XLineAlignment.Near,
                     Alignment = XStringAlignment.Near
                 });

            foreach (var item in estoqueSangues)
            {
                heightPdf += 30;
                gfx.DrawString(
                   $"Quantidade ML:{item.QuantidadeMl} - Fator RH: {item.FatorRh} - Data doação: {item.DataDoacao.ToString("dd-MM-yyyy")}",
                   new XFont("Verdana", 12, XFontStyle.Regular), XBrushes.Black,
                   new XRect(20, heightPdf, page.Width, page.Height),
                   new XStringFormat()
                   {
                       LineAlignment = XLineAlignment.Near,
                       Alignment = XStringAlignment.Near
                   });

            }

            gfx.DrawString(
                  $"Total doações: {estoqueSangues.Count}",
                  new XFont("Verdana", 12, XFontStyle.Regular), XBrushes.Black,
                  new XRect(20, heightPdf += 30, page.Width, page.Height),
                  new XStringFormat()
                  {
                      LineAlignment = XLineAlignment.Near,
                      Alignment = XStringAlignment.Near
                  });

            return heightPdf;
        }
    }
}

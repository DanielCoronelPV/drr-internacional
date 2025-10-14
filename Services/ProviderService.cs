using DRR_PRESENTATION.Models;

namespace DRR_PRESENTATION.Services
{
    public class ProviderService
    {
        private List<Provider> ProvidersList = new()
        {
            new Provider
            {
                Id = "1",
                Name = "Zanotelli International Consultancy",
                LogoUrl = "assets/img/prestadores/zanotelli.png",
                Category = "Comercio Internacional",
                Rating = 4.8,
                ReviewCount = 125,
                Description = "Consultoría internacional que conecta productos, oportunidades y mercados. Especializada en el comercio de equipos industriales y piedras preciosas.",
                Location = "São Miguel do Oeste, SC, Brazil",
                Pricing = new PricingInfo
                {
                    Range = "Negociable",
                    Type = "Basado en proyecto"
                },
                Contact = new ContactInfo
                {
                    Email = "consultoria@zanotelli.com.br",
                    Phone = "+55 (49) 98808-1444",
                    Website = "https://zanotelli.com.br"
                },
                Services = new() { "Comercio de Equipos Industriales", "Exportación de Piedras Preciosas", "Consultoría de Negocios Internacionales", "Servicios de importación y exportación" },
                Features = new() { "Representación exclusiva en Sudamérica", "Certificación de Calidad", "Red Internacional", "Soluciones a la Medida" },
                Portfolio = new()
                {
                    new PortfolioProject
                    {
                        Title = "Plataforma de descarga trasera BAOSHENG",
                        Description = "Representante exclusivo en Sudamérica de equipos de descarga industrial BAOSHENG con capacidad hasta 100 toneladas",
                        Image = "assets/img/prestadores/zanotelli-logo.png",
                        URLpdf = "assets/pdf/prestadores/PLATAFORMA DE DESCARGA TRASEIRA BAOSHENG -  ZANOTELLI INTERNATIONAL CONSULTANCI.pdf"
                    },
                    new PortfolioProject
                    {
                        Title = "Piedras preciosas brasileñas",
                        Description = "Piedras preciosas brasileñas certificadas, incluidas turmalina de Paraíba, esmeralda, topacio imperial y más",
                        Image = "assets/img/prestadores/zanotelli-piedras-preciosas.png",
                        URLpdf = "assets/pdf/prestadores/PEDRAS PRECIOSAS -  ZANOTELLI INTERNATIONAL CONSULTANCI.pdf"
                    }
                },
            },

            new Provider
            {
                Id = "2",
                Name = "DRR Systemas",
                LogoUrl = "assets/img/faviconDrr.png",
                Category = "Systemas de Gestión",
                Rating = 4.9,
                ReviewCount = 93,
                Description = "Ayudamos a todo tipo de empresas a favorecer el desarrollo interno de su negocio.",
                Location = "Eldorado, Argentina",
                Pricing = new PricingInfo
                {
                    Range = "Negociable",
                    Type = "Basado en Proyecto"
                },
                Contact = new ContactInfo
                {
                    Email = "info@drrsystemas.com",
                    Phone = "+55 11 99999-9999",
                    Website = "https://drrsystemas.github.io/drr-page/"
                },
                Services = new() { "Desarrollo de ERP, CRM", "Sistemas personalizados", "Creación de aplicaciones web modernas" },
                Features = new() { "Agilidad", "Certificación", "Experiencia internacional" },
                Portfolio = new()
                {
                    new PortfolioProject
                    {
                        Title = "Plataforma BAOSHENG instalada",
                        Description = "Proyecto de logística internacional",
                        Image = "assets/img/prestadores/zanotelli-logo.png",
                        URLpdf = "assets/pdf/prestadores/PLATAFORMA DE DESCARGA TRASEIRA BAOSHENG -  ZANOTELLI INTERNATIONAL CONSULTANCI.pdf"
                    },
                    new PortfolioProject
                    {
                        Title = "Catálogo de gemas",
                        Description = "Selección de pedras preciosas brasileiras",
                        Image = "assets/img/prestadores/zanotelli-piedras-preciosas.png",
                        URLpdf = "assets/pdf/prestadores/PEDRAS PRECIOSAS -  ZANOTELLI INTERNATIONAL CONSULTANCI.pdf"
                    }
                },
            }
        };

        public List<Provider> GetProviders() => ProvidersList;

        public Provider? GetProviderById(string id) =>
            ProvidersList.FirstOrDefault(p => p.Id == id);
    }
}

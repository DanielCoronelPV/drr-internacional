using System.Collections.Generic;

namespace DRR_PRESENTATION.Models
{
    public class Provider
    {
        public string Id { get; set; } = string.Empty; // puede ser string/slug
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public string Location { get; set; } = string.Empty;
        public PricingInfo Pricing { get; set; } = new();
        public ContactInfo Contact { get; set; } = new();
        public List<string> Services { get; set; } = new();
        public List<string> Features { get; set; } = new();
        public List<PortfolioProject> Portfolio { get; set; } = new();
    }

    public class PricingInfo
    {
        public string Type { get; set; } = string.Empty;
        public string Range { get; set; } = string.Empty;
    }

    public class ContactInfo
    {
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
    }

    public class PortfolioProject
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string URLpdf { get; set; } = string.Empty;

    }
}

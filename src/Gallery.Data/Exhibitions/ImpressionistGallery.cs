using Gallery.Core.Models;

namespace Gallery.Data.Exhibitions;

public static class ImpressionistGallery
{
    public static Exhibition Create()
    {
        var exhibition = new Exhibition
        {
            Name = "Chiaroscuro: Impressionist Masters",
            Subtitle = "A virtual walk through turn-of-the-century Parisian salons",
            Curator = "Gallery Prototype",
            Artworks = new List<Artwork>
            {
                new()
                {
                    Id = "pissarro-1899-tuileries",
                    Title = "The Garden of the Tuileries on a Winter Afternoon",
                    Artist = "Camille Pissarro",
                    Date = "1899",
                    Medium = "Oil on canvas",
                    Dimensions = "73.7 × 92.1 cm (29 × 36 1/4 in.)",
                    CreditLine = "Gift of Katrin S. Vietor, in loving memory of Ernest G. Vietor, 1966. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/437314",
                    ImageFileName = "pissarro-tuileries.jpg",
                    Room = "Room 1 — The Boulevards",
                    Description = "A quiet, silvery view of the Tuileries Gardens in winter, alive with subtle shifts of light and atmosphere.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "renoir-1892-two-girls-piano",
                    Title = "Two Young Girls at the Piano",
                    Artist = "Auguste Renoir",
                    Date = "1892",
                    Medium = "Oil on canvas",
                    Dimensions = "111.8 × 86.4 cm (44 × 34 in.)",
                    CreditLine = "Robert Lehman Collection, 1975. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/459112",
                    ImageFileName = "renoir-two-girls.jpg",
                    Room = "Room 1 — The Boulevards",
                    Description = "Intimacy and warmth rendered with Renoir's characteristic tenderness and lush handling of paint.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "degas-1874-dance-class",
                    Title = "The Dance Class",
                    Artist = "Edgar Degas",
                    Date = "1874",
                    Medium = "Oil on canvas",
                    Dimensions = "83.5 × 77.2 cm (32 7/8 × 30 3/8 in.)",
                    CreditLine = "Bequest of Mrs. Harry Payne Bingham, 1986. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/438817",
                    ImageFileName = "degas-dance-class.jpg",
                    Room = "Room 2 — The Studio",
                    Description = "A candid glimpse into the Paris Opéra ballet studio, observed from an unconventional, almost photographic angle.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "van-gogh-1889-wheat-field-cypresses",
                    Title = "Wheat Field with Cypresses",
                    Artist = "Vincent van Gogh",
                    Date = "1889",
                    Medium = "Oil on canvas",
                    Dimensions = "73.2 × 93.4 cm (28 13/16 × 36 3/4 in.)",
                    CreditLine = "Purchase, The Annenberg Foundation Gift, 1993. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/436535",
                    ImageFileName = "van-gogh-wheat-field.jpg",
                    Room = "Room 3 — The Countryside",
                    Description = "Turbulent sky and flame-like cypress trees convey Van Gogh's heightened emotional response to nature.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "cezanne-1902-mont-sainte-victoire",
                    Title = "Mont Sainte-Victoire",
                    Artist = "Paul Cézanne",
                    Date = "ca. 1902–1906",
                    Medium = "Oil on canvas",
                    Dimensions = "57.2 × 97.2 cm (22 1/2 × 38 1/4 in.)",
                    CreditLine = "The Walter H. and Leonore Annenberg Collection, 1994. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/435878",
                    ImageFileName = "cezanne-mont-sainte-victoire.jpg",
                    Room = "Room 3 — The Countryside",
                    Description = "Cézanne's methodical building of form with color laid the groundwork for Cubism.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "seurat-1884-grande-jatte-study",
                    Title = "Study for \"A Sunday on La Grande Jatte\"",
                    Artist = "Georges Seurat",
                    Date = "1884",
                    Medium = "Oil on canvas",
                    Dimensions = "70.5 × 104.1 cm (27 3/4 × 41 in.)",
                    CreditLine = "Bequest of Sam A. Lewisohn, 1951. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/437658",
                    ImageFileName = "seurat-grande-jatte-study.jpg",
                    Room = "Room 4 — Pointillism",
                    Description = "A preparatory study demonstrating Seurat's meticulous dot technique and carefully observed light.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "klimt-1912-mada-primavesi",
                    Title = "Mäda Primavesi (1903–2000)",
                    Artist = "Gustav Klimt",
                    Date = "1912–1913",
                    Medium = "Oil on canvas",
                    Dimensions = "149.9 × 110.5 cm (59 × 43 1/2 in.)",
                    CreditLine = "Gift of André and Clara Mertens, 1964. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/436819",
                    ImageFileName = "klimt-mada-primavesi.jpg",
                    Room = "Room 5 — Vienna Secession",
                    Description = "A vibrant, decorative portrait of a young girl standing in a blossoming landscape of pattern and color.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "hokusai-1830-great-wave",
                    Title = "Under the Wave off Kanagawa (The Great Wave)",
                    Artist = "Katsushika Hokusai",
                    Date = "ca. 1830–1832",
                    Medium = "Woodblock print; ink and color on paper",
                    Dimensions = "25.4 × 38.1 cm (10 × 15 in.)",
                    CreditLine = "The Howard Mansfield Collection, Purchase, Rogers Fund, 1936. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/39799",
                    ImageFileName = "hokusai-great-wave.jpg",
                    Room = "Room 6 — Ukiyo-e",
                    Description = "An iconic ukiyo-e print of a towering wave threatening boats beneath Mount Fuji.",
                    IsPublicDomain = true
                },
                new()
                {
                    Id = "vermeer-1662-water-pitcher",
                    Title = "Young Woman with a Water Pitcher",
                    Artist = "Johannes Vermeer",
                    Date = "ca. 1662",
                    Medium = "Oil on canvas",
                    Dimensions = "45.7 × 40.6 cm (18 × 16 in.)",
                    CreditLine = "Marquand Collection, Gift of Henry G. Marquand, 1889. The Metropolitan Museum of Art, New York.",
                    CollectionUrl = "https://www.metmuseum.org/art/collection/search/437881",
                    ImageFileName = "vermeer-water-pitcher.jpg",
                    Room = "Room 7 — Dutch Golden Age",
                    Description = "A masterclass in light and stillness, capturing a moment of quiet domestic ritual.",
                    IsPublicDomain = true
                }
            }
        };

        return exhibition;
    }
}

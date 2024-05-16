using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "GymWebsite.Module",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "GymWebsite.Module",
    Category = "Content Management",
    Dependencies = new[] { "OrchardCore.ContentFields", "OrchardCore.Media" }
)]

using System;
using System.Collections.Generic;

namespace Personeel.Models.ModelsOracle;

public partial class Personeel
{
    public string Codpersoneel { get; set; } = null!;

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    public string? Naam { get; set; }

    public string? Voornaam { get; set; }

    public string? Webpw { get; set; }

    public string? Email { get; set; }

    public string? Rijksregisternummer { get; set; }

    public string Taal { get; set; } = null!;

    public bool? Nbrtrylogin { get; set; }

    public bool? Islockedout { get; set; }
}

using System;
using System.Collections.Generic;

namespace Document_Documenttype.Models.ModelsOracle;

public partial class Documenttype
{
    public long Seqdocumenttype { get; set; }

    public string? Beschrijving { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Emailmaintemplate { get; set; }

    public string? Pdfmaintemplate { get; set; }

    public long? Priority { get; set; }

    public int? SeqtransTitle { get; set; }

    /*    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    */
}

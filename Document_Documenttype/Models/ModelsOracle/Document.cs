using System;
using System.Collections.Generic;

namespace Document_Documenttype.Models.ModelsOracle;

public partial class Document
{
    public long Seqdocument { get; set; }

    public string? Creusr { get; set; }

    public string? Updusr { get; set; }

    public DateTime Credat { get; set; }

    public DateTime Upddat { get; set; }

    public string? Bericht { get; set; }

    public string? Documentguid { get; set; }

    public decimal? Mailopenedcount { get; set; }

    public DateTime Mailopeneddate { get; set; }

    public long? Seqdocumenttype { get; set; }

    public int? Seqlang { get; set; }

    //public virtual Documenttype? SeqdocumenttypeNavigation { get; set; }
}

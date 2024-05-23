using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestBericht.DAL;

public class DocumentController : Controller
{
    private readonly OracleDataAccess _oracleDataAccess;
    private readonly CockroachDbDataAccess _cockroachDbDataAccess;

    public DocumentController(OracleDataAccess oracleDataAccess, CockroachDbDataAccess cockroachDbDataAccess)
    {
        _oracleDataAccess = oracleDataAccess;
        _cockroachDbDataAccess = cockroachDbDataAccess;
    }

    public async Task<IActionResult> OracleDocument()
    {
        var content = await _oracleDataAccess.GetClobContentAsync();
        return View("DisplayDocument", content);
    }

    public async Task<IActionResult> CockroachDbDocument()
    {
        var content = await _cockroachDbDataAccess.GetStringContentAsync();
        return View("DisplayDocument", content);
    }
}

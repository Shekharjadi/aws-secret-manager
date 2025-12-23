using Microsoft.AspNetCore.Mvc;
using AwsSecretManager.Data;
using aws_secret_manager.Models;
public class DocumentController : Controller
{
    private readonly ApplicationDbContext _context;

    public DocumentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var documents = _context.Documents.Where(d => d.IsActive).ToList();
        return View(documents);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Document document)
    {
        document.CreatedDate = DateTime.Now;
        document.IsActive = true;

        _context.Documents.Add(document);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var doc = _context.Documents.Find(id);
        return View(doc);
    }

    [HttpPost]
    public IActionResult Edit(Document document)
    {
        _context.Documents.Update(document);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var doc = _context.Documents.Find(id);
        return View(doc);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var doc = _context.Documents.Find(id);
        doc.IsActive = false; // Soft delete
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

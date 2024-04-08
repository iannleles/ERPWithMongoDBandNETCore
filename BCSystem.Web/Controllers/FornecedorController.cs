using BCSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;


public class FornecedorController : Controller
{
    private readonly FornecedorRepositorio _repository;

    public FornecedorController(FornecedorRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        List<Fornecedor> Fornecedors = await _repository.GetAllFornecedors();
        return View(Fornecedors);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Fornecedor = await _repository.GetFornecedor(id);
        if (Fornecedor == null)
        {
            return NotFound();
        }

        return View(Fornecedor);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Fornecedor Fornecedor)
    {
        await _repository.CreateFornecedor(Fornecedor);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        Fornecedor Fornecedor = await _repository.GetFornecedor(id);
        return View(Fornecedor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, Fornecedor Fornecedor)
    {
        await _repository.UpdateFornecedor(id, Fornecedor);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        Fornecedor Fornecedor = await _repository.GetFornecedor(id);
        return View(Fornecedor);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _repository.DeleteFornecedor(id);
        return RedirectToAction("Index");
    }
}

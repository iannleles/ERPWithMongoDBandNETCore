using Microsoft.AspNetCore.Mvc;


public class ProdutoController : Controller
{
    private readonly ProdutoRepositorio _repository;

    public ProdutoController(ProdutoRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        List<Produto> produtos = await _repository.GetAllProdutos();
        return View(produtos);
    }

    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produto = await _repository.GetProduto(id);
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Produto produto)
    {
        await _repository.CreateProduto(produto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(string id)
    {
        Produto produto = await _repository.GetProduto(id);
        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, Produto produto)
    {
        await _repository.UpdateProduto(id, produto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(string id)
    {
        Produto produto = await _repository.GetProduto(id);
        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _repository.DeleteProduto(id);
        return RedirectToAction("Index");
    }
}

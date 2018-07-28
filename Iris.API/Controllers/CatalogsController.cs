using Iris.Models;
using Iris.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iris.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalogs")]
    public class CatalogsController : Controller
    {
        private readonly ICatalogService service;

        public CatalogsController(ICatalogService _service)
        {
            service = _service;
        }

        // GET: api/Catalogs
        [HttpGet]
        public IEnumerable<CatalogItemData> GetCatalogs()
        {
            return service.GetCatalogItems();
        }

        // GET: api/Catalogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catalog = await service.FindCatalogItemByAsync(id);

            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalog([FromRoute] int id, [FromBody] UpdateCatalogItemData catalogItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalogItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await service.UpdateCatalogItemAsync(id, catalogItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.DoesCatalogItemExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Catalogs
        [HttpPost]
        public async Task<IActionResult> PostCatalog([FromBody] AddCatalogItemData catalogItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int catalogId = await service.CreateAsync(catalogItem);

            return CreatedAtAction(nameof(GetCatalog), new { id = catalogId }, catalogItem);
        }

        // DELETE: api/Catalogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catalog = await service.FindCatalogItemByAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            await service.DeleteCatalogId(id);

            return Ok(catalog);
        }
    }
}
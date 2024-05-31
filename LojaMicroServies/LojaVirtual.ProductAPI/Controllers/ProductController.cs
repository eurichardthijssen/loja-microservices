﻿using LojaVirtual.ProductAPI.Data.ValueObjects;
using LojaVirtual.ProductAPI.Repository;
using LojaVirtual.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            return Ok(product);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> FindByID(long id)
        {
            var product = await _repository.FindById(id);
            if (product.Id <= 0) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody]ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}

using System;
using AppFidelidade.MobileAppService.Interfaces;
using AppFidelidade.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFidelidade.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_estabelecimentoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Estabelecimento GetItem(string id)
        {
            Estabelecimento estabelecimento = _estabelecimentoRepository.Get(id);
            return estabelecimento;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Estabelecimento estabelecimento)
        {
            try
            {
                if (estabelecimento == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                _estabelecimentoRepository.Add(estabelecimento);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(estabelecimento);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                if (estabelecimento == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                _estabelecimentoRepository.Update(estabelecimento);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _estabelecimentoRepository.Remove(id);
        }
    }
}
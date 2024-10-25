using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;
        private readonly IMapper _mapper;
        public FeaturesController(IFeatureService FeatureService, IMapper mapper)
        {
            _FeatureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _FeatureService.TGetListAll();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _FeatureService.TAdd(value);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _FeatureService.TGetByID(id);
            _FeatureService.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _FeatureService.TUpdate(value);
            return Ok("Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _FeatureService.TGetByID(id);
            return Ok(_mapper.Map<GetFeatureDto>(value));
        }
    }
}

using Asp.Versioning;
using Bale.Identity.Application.Sample.Commands;
using Bale.Identity.Constract.Sample;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bale.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [ApiVersion(2, Deprecated = true)]
    public class SampleController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public SampleController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the version 1 of the API
        /// </summary>
        /// <returns>Sample API</returns>
        [HttpGet]
        //[Route("")]
        [MapToApiVersion(1)]
        public IActionResult Get1()
        {
            //return Ok("v1");
            throw new Exception("test");

        }

        [HttpGet]
        //[Route("")]
        [MapToApiVersion(2)]
        public IActionResult Get2()
        {
            return Ok("test api");
        }

        public IActionResult SamplePost(CreateSampleRequest request)
        {
            var cmd = _mapper.Map<CreateSampleCommand>(request);

            var result = _sender.Send(cmd);

            return Ok(result);
        }
    }
}

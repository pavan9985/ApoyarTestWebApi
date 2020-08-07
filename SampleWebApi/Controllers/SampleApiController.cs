using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace SampleWebApi.Controllers
{
    [Route("SampleController")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        [Route("SampleCRUD")]
        [HttpPost]
        public async Task<IActionResult> Sample_Main(InputModel inputModel)
        {
            OuputModel outputModel = null;
            try
            {
                if (inputModel == null)
                {
                    return BadRequest(outputModel);
                }
                ActionFlow actionFlow = new ActionFlow();

                outputModel = await actionFlow.SampleActionFlow(inputModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(outputModel);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using GuitarLocker.Models;
using GuitarLocker.ViewModels;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Net;
using GuitarLocker.Services;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Wildermuth.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GuitarLocker.Controllers.API
{
    [Authorize]
    [Route("api/Instruments/{InstrumentName}/Images")]
    public class ImageController : Controller
    {
        private IGuitarLockerRepository _repository;
        private ILogger<ImageController> _logger;
        private CoordService _coordService;

        public ImageController(IGuitarLockerRepository repository, ILogger<ImageController> logger, CoordService coordService)
        {
            _repository = repository;
            _logger = logger;
            _coordService = coordService;
        }

        [HttpGet("")]
        public JsonResult Get(string InstrumentName)
        {
            try
            {
                var results = _repository.GetInstrumentByName(InstrumentName, User.Identity.Name);
                if (results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<ImageViewModel>>(results.Images));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get {InstrumentName}", ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("an error occured");
            }
        }

        //public async Task<JsonResult> Post(string InstrumentName, [FromBody]ImageViewModel vm)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // Map to Entity
        //            var newImage = Mapper.Map<Image>(vm);
        //            // Look up GeoCordinates
        //            var coordResult = await _coordService.Lookup(newImage.Name);

        //            if (!coordResult.Success)
        //            {
        //                Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //                Json(coordResult.Message);
        //            }

        //            newImage.Longitude = coordResult.Longitude;
        //            newImage.Latitude = coordResult.Latitude;
        //            //Save to the Database
        //            _repository.AddImage(InstrumentName, newImage, User.Identity.Name);

        //            if (_repository.SaveAll())
        //            {
        //                Response.StatusCode = (int)HttpStatusCode.Created;
        //                return Json(Mapper.Map<ImageViewModel>(newImage));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get {InstrumentName}", ex.Message);
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json("Failed to save new Image");
        //    }
        //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //    return Json("Validation failed on new Image");
        //}
    }
}

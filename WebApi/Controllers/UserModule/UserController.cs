using Application.UserModule.Interfaces;
using Crosscrutting.Exceptions;
using DTO.UserModule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Resources;

namespace WebApi.Controllers.UserModule
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<UserDto> GetAll()

        {
            var users = _userAppService.GetAll();
            return users;
        }

        [HttpGet]
        [Route("get/{id}")]        
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var user = _userAppService.Get(id);
                return Ok(user); 
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorResource.ErrGeneric);
            }
        }

        [HttpPost]
        [Route("create/{user}")]        
        public IHttpActionResult Post([FromBody]UserDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorResource.NotValidModel);
                var userResult = _userAppService.Add(user);
                return Ok(userResult);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorResource.ErrGeneric);
            }
        }

        [HttpPut]
        [Route("update/{user}")]
        public IHttpActionResult Put([FromBody]UserDto user)
        {
            try
            {
                var userResult = _userAppService.Update(user);
                return Ok(userResult);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorResource.ErrGeneric);
            }
            
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _userAppService.Delete(id);
                return Ok();
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorResource.ErrGeneric);
            }
            
        }
    }
}

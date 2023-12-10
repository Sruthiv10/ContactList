using AutoMapper;
using ContactList.Application.DTO;
using ContactList.Application.Interface;
using ContactList.Application.Models;
using ContactList.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class ContactListController : Controller
    {
        private readonly IContactListAppService contactListAppService;
        private readonly IMapper mapper;
      

        public ContactListController(IContactListAppService contactListAppService, IMapper mapper)
        {
            this.contactListAppService = contactListAppService;
            this.mapper = mapper;            
        }
       
        /// Create Contact.       
        [HttpPost(Name = "CreateContact")]
        [ProducesResponseType(typeof(ContactListViewModel), 200)]       
        public IActionResult Post([FromBody] ContactListCreateModel contactCreateModel)
        {
            try
            {
                ContactListDTO ContactListDto = mapper.Map<ContactListDTO>(contactCreateModel);                

                var data = contactListAppService.Save(ContactListDto);

                if (data.Success)
                {

                    var viewModel = mapper.Map<IEnumerable<ContactListViewModel>>(data.Results);                   
                    return Ok(new { data.Messages.FirstOrDefault()?.Description, viewModel });
                }
                else
                {
                    return BadRequest(data.Messages.FirstOrDefault()?.Description);
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieve All Contacts.
        /// </summary>
        /// <returns>ResultModel ContactListViewModel.</returns>
        [HttpGet(Name = "GetContactList")]
        [ProducesResponseType(typeof(List<ContactListViewModel>), 200)]
        public IActionResult Get()
        {
            try
            {
                var data = contactListAppService.GetAll();
                if (data.Success)
                {
                    var viewModelList = mapper.Map<List<ContactListViewModel>>(data.Results); // Note the change here
                    return Ok(new { data.Messages.FirstOrDefault()?.Description, ContactListViewModel = viewModelList });
                }
                else
                {
                    return BadRequest(data.Messages.FirstOrDefault()?.Description);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieve Contact details.
        /// </summary>
        /// <param name="ContactId">ContactId.</param>
        /// <returns>ResultModel ContactListViewModel.</returns>
        [HttpGet("{contactId}", Name = "GetContactById")]
        [ProducesResponseType(typeof(List<ContactListViewModel>), 200)]      
        public IActionResult Get(int contactId)
        {
            try
            {
                var data = contactListAppService.Get(contactId);
                if (data.Success)
                {

                    var viewModel = mapper.Map<ContactListViewModel>(data.Result);
                    return Ok(new { data.Messages.FirstOrDefault()?.Description, ContactListViewModel = viewModel });
                }
                else
                {
                    return BadRequest(data.Messages.FirstOrDefault()?.Description);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut(Name = "UpdateContact")]
        [ProducesResponseType(typeof(ContactListViewModel), 200)]        
        public IActionResult Put([FromBody] ContactListEditModel contactEditModel)
        {
            try
            {
                ContactListDTO contactDto = mapper.Map<ContactListDTO>(contactEditModel);               

                var data = contactListAppService.Modify(contactDto);

                if (data.Success)
                {

                    var viewModelList = mapper.Map<IEnumerable<ContactListViewModel>>(data.Results);                    
                    return Ok(new { data.Messages.FirstOrDefault()?.Description, viewModelList });
                }
                else
                {
                    return BadRequest(data.Messages.FirstOrDefault()?.Description);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{contactId}", Name = "DeleteContact")]
        [ProducesResponseType(typeof(List<ContactListViewModel>), 200)]       
        public IActionResult Delete(int contactId)
        {
            try
            {
                var data = contactListAppService.Delete(contactId);
                if (data.Success)
                {

                    var viewModel = mapper.Map<IEnumerable<ContactListViewModel>>(data.Results);                   
                    return Ok(new { data.Messages.FirstOrDefault()?.Description, viewModel });
                }
                else
                {
                    return BadRequest(data.Messages.FirstOrDefault()?.Description);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [Route("GetByPage")]
        [HttpGet]
        [ProducesResponseType(typeof(ExecuteResult<ContactListViewModel>), 200)]       
        public IActionResult GetByPage([FromQuery] PageSearchModel model)
        {
            try
            {
                var data = contactListAppService.GetByPage(model.PageNumber, model.RowCount, model.SearchText, model.SortDirection != null ? model.SortDirection.ToUpper() : model.SortDirection);
                if (data.Success)
                {
                    var viewModelList = mapper.Map<IEnumerable<ContactListViewModel>>(data.Results);
                    //var viewModel = mapper.Map<ExecuteResult<ContactListViewModel>>(data);
                    return Ok(new { data.Messages.FirstOrDefault()?.Description, viewModelList });
                   
                }
                else
                {
                    return BadRequest(data.Messages.FirstOrDefault()?.Description);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}

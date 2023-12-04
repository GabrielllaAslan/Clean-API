using Application.Commands.Dogs;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Application.Validators;
using Application.Validators.Dog;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly DogValidator _dogvalidator;
        internal readonly GuidValidator _guidvalidator;
        public DogsController(IMediator mediator,DogValidator dogvalidator,GuidValidator guidvalidator)
        {
            _mediator = mediator;
            _dogvalidator = dogvalidator;
            _guidvalidator = guidvalidator;
            
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
            //return Ok("GET ALL DOGS");
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            var guidvalidator = _guidvalidator.Validate(dogId);
            
            if(! guidvalidator.IsValid)
            {

                return BadRequest(guidvalidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            
            return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            ///Validate dog
            var dogvalidator = _dogvalidator.Validate(newDog);
           
            // Error handling
            if(!dogvalidator.IsValid)
            {
                return BadRequest(dogvalidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try,Catch
            try
            {
                return Ok(await _mediator.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto dogToUpdate, Guid updatedDogById)
        {

            var dogvalidator = _dogvalidator.Validate(dogToUpdate);
            var guidvalidator = _guidvalidator.Validate(updatedDogById);

            if(!guidvalidator.IsValid) 
            {
                return BadRequest(guidvalidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }


            if(!dogvalidator.IsValid)
            {
                return BadRequest(dogvalidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var dog = await _mediator.Send(new UpdateDogByIdCommand(dogToUpdate, updatedDogById));
            
            if(dog == null)
            {
                return NotFound($"Dog with Id:{updatedDogById} does not exist in database");
            }
            return Ok(dog);
        }

        // IMPLEMENT DELETE !!!
        // Retunera (return NoContent(); när jag skriver validering för delete)!
    }
}

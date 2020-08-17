using PhoneBook.DAL;
using PhoneBook.Service;
using PhoneBookWeb.BasicAuthN;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Routing;

namespace PhoneBookWeb.Controllers
{
    [EnableCors(origins: "https://localhost:44371", headers: "*", methods: "*")]
    [BasicAuthentication]
    public class CountryController : ApiController
    {
        CountryService countryService;
        public CountryController()
        {
            countryService = new CountryService();
        }


        // GET: Country
        public IEnumerable<Country> Get()
        {
            return countryService.GetCountries();
        }

        public IEnumerable<Country> Add(Country country)
        {
            return countryService.AddCountries(country);
        }

        //[Route("{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] Country country)
        {
            try
            {
                if (id == default(int))
                {
                    return NotFound();
                }
                country.CountryId = id;
                Country result = countryService.UpdateCountries(country);

                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id == default(int))
                {
                    return NotFound();
                }
                Country result = countryService.DeleteCountries(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}

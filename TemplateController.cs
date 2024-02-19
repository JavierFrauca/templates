
using AutoMapper;
using [PROYECT_NAME].Data.V1;
using [PROYECT_NAME].DTO.V1;
using [PROYECT_NAME].Entity.V1;
using [PROYECT_NAME].Mappers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace [PROYECT_NAME].Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "V1")]
    [ApiController]
    [Authorize]
    public class [CONTROLER_NAME]Controller : ControllerBase
    {
        private readonly [PROYECT_NAME]Context _context;
        private readonly IConfiguration _configuration;
        private readonly Mapper mapper = new(new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()));


        public [CONTROLER_NAME]Controller([PROYECT_NAME]Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/[CONTROLER_NAME]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<[CONTROLER_NAME]sDto>>> Get[CONTROLER_NAME]s()
        {
            //cargamos datos del token
            string? ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            string? token = Request.Headers["Authorization"];
            var tokendata = new TokenController(_context, _configuration).ValidarToken(token, ip, 0, 0);
            if (tokendata.Permitido == true)
            {
                var [CONTROLER_NAME] = await _context.[CONTROLER_NAME].ToListAsync();
                MapperConfiguration configuration = new(cfg => cfg.AddProfile<AutoMapperProfile>());
                IMapper mapper = configuration.CreateMapper();
                List<[CONTROLER_NAME]Dto> [CONTROLER_NAME]Dto = mapper.Map<List<[CONTROLER_NAME]sDto>>([CONTROLER_NAME]s);
                return Ok([CONTROLER_NAME]Dto);
            }
            else
            {
                return Unauthorized();
            }

        }

        // GET: api/[CONTROLER_NAME]s/5
        [HttpGet("{id}")]
        public async Task<ActionResult<[CONTROLER_NAME]Dto>> Get[CONTROLER_NAME](int id)
        {
            //cargamos datos del token
            string? ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            string? token = Request.Headers["Authorization"];
            var tokendata = new TokenController(_context, _configuration).ValidarToken(token, ip, 0, 0);
            if (tokendata.Permitido == true)
            {
                if (_context.[CONTROLER_NAME]s == null)
                {
                    return NotFound();
                }
                var [CONTROLER_NAME] = await _context.[CONTROLER_NAME]s.FindAsync(id);

                if ([CONTROLER_NAME] == null)
                {
                    return NotFound();
                }
                [CONTROLER_NAME]Dto [CONTROLER_NAME]Dto = mapper.Map<[CONTROLER_NAME]Dto>([CONTROLER_NAME]);
                return [CONTROLER_NAME]Dto;
            }
            else
            {
                return Unauthorized();
            }

        }

        // PUT: api/[CONTROLER_NAME]s/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put[CONTROLER_NAME](int id, [CONTROLER_NAME]Dto [CONTROLER_NAME])
        {
            //cargamos datos del token
            string? ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            string? token = Request.Headers["Authorization"];
            var tokendata = new TokenController(_context, _configuration).ValidarToken(token, ip, 0, 0);
            if (tokendata.Permitido == true)
            {
                if (id != [CONTROLER_NAME].Id)
                {
                    return BadRequest();
                }
                var c = await _context.[CONTROLER_NAME]s.FindAsync(id);
                if (c == null)
                {
                    return NotFound();
                }
                else
                {
                    [CONTROLER_NAME]Entity [CONTROLER_NAME]Entity = c;
                    mapper.Map([CONTROLER_NAME], [CONTROLER_NAME]Entity);
                    _context.Entry([CONTROLER_NAME]Entity).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (![CONTROLER_NAME]Exists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return NoContent();
                }
            }
            else
            {
                return Unauthorized();
            }

        }

        // POST: api/[CONTROLER_NAME]s
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<[CONTROLER_NAME]Dto>> Post[CONTROLER_NAME]([CONTROLER_NAME]Dto [CONTROLER_NAME])
        {
            //cargamos datos del token
            string? ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            string? token = Request.Headers["Authorization"];
            var tokendata = new TokenController(_context, _configuration).ValidarToken(token, ip, 0, 0);
            if (tokendata.Permitido == true)
            {
                if (_context.[CONTROLER_NAME]s == null)
                {
                    return Problem("Entity set '[PROYECT_NAME]Context.[CONTROLER_NAME]s'  is null.");
                }
                [CONTROLER_NAME]Entity [CONTROLER_NAME]Entity = mapper.Map<[CONTROLER_NAME]Entity>([CONTROLER_NAME]);
                _context.[CONTROLER_NAME]s.Add([CONTROLER_NAME]Entity);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get[CONTROLER_NAME]", new { id = [CONTROLER_NAME]Entity.Id }, [CONTROLER_NAME]);
            }
            else
            {
                return Unauthorized();
            }
        }

        // DELETE: api/[CONTROLER_NAME]s/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete[CONTROLER_NAME](int id)
        {
            //cargamos datos del token
            string? ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            string? token = Request.Headers["Authorization"];
            var tokendata = new TokenController(_context, _configuration).ValidarToken(token, ip, 0, 0);
            if (tokendata.Permitido == true)
            {
                if (_context.[CONTROLER_NAME]s == null)
                {
                    return NotFound();
                }
                var [CONTROLER_NAME] = await _context.[CONTROLER_NAME]s.FindAsync(id);
                if ([CONTROLER_NAME] == null)
                {
                    return NotFound();
                }

                _context.[CONTROLER_NAME]s.Remove([CONTROLER_NAME]);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        private bool [CONTROLER_NAME]Exists(int id)
        {
            return (_context.[CONTROLER_NAME]s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

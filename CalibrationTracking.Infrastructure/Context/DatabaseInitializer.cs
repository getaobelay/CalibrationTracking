using AutoMapper;
using CalibrationTracking.Core.Departments;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Infrastructure.Properties;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using CalibrationTracking.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CalibrationTracking.Infrastructure.Context
{

    public class DatabaseInitializer : IDatabaseInitializer
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DatabaseInitializer> _logger;

        /// <summary>
        /// The context
        /// </summary>
        private readonly CalibrationDbContext _context;

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly IUserService _userManager;

        /// <summary>
        /// The role manager
        /// </summary>
        private readonly IRoleService _roleManager;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseInitializer"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        public DatabaseInitializer(ILogger<DatabaseInitializer> logger,
            IMapper mapper,
                                               CalibrationDbContext context,
                                               IUserService userManager,
                                               IRoleService roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Initialises the asynchronous.
        /// </summary>
        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        /// <summary>
        /// Tries the seed asynchronous.
        /// </summary>
        public async Task TrySeedAsync()
        {
            if (!_context.Departments.Any())
            {
                var departments = JsonHelpers.GetJsonResourceAsObject<List<Department>>(Resources.departments);

                departments = departments.DistinctBy(x => x.Name).ToList();

                await _context.AddRangeAsync(departments);
            }



            await _context.SaveChangesAsync();
        }



        /// <summary>
        /// Gets the json resource as object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">resourceName</exception>
        private T GetJsonResourceAsObject<T>(string resourceName)
        {
            string streamResult;

            using (StreamReader reader = new StreamReader(resourceName))
            {
                streamResult = reader.ReadToEnd();
            }

            var jsonResult = JsonConvert.DeserializeObject<T>(streamResult);

            if (jsonResult == null) throw new ArgumentNullException(nameof(resourceName));

            return jsonResult;
        }
    }
}

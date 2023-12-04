using ILCS_restfulAPI.Services;

namespace ILCS_restfulAPI; 

public class Startup {
    public void ConfigureServices(IServiceCollection services)
    {
        // Other service registrations...

        // Register BarangService as a singleton
        // services.AddSingleton<BarangService>();

        // Other configurations...
    }
}
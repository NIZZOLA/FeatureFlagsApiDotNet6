using Microsoft.FeatureManagement;

namespace FeatureFlagsApi.Services
{
    public class MyService
    {
        private readonly IFeatureManager _featureManager;
        public MyService(IFeatureManagerSnapshot featureManager)
        {
            _featureManager = featureManager;
        }
        public async Task<string> Process()
        {
            // Verifica se o recurso "NewMethod" está habilitado
            if (await _featureManager.IsEnabledAsync("NewMethod"))
            {
                Console.WriteLine("Executando o método novo...");
                return NewMethod();
            }
            else
            {
                Console.WriteLine("Executando o método legado...");
                return LegacyMethod();
            }
        }

        public string NewMethod()
        {
            return "Novo Método";
        }
        public string LegacyMethod()
        {
            return "Método legado";
        }
    }
}

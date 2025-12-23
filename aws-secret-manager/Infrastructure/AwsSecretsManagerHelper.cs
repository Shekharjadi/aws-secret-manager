using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace aws_secret_manager.Infrastructure
{
    public static class AwsSecretsManagerHelper
    {
        public static async Task<string> GetSecretAsync(
            string secretName,
            string region)
        {
            // 🔥 Disable EC2 metadata lookup
            Environment.SetEnvironmentVariable("AWS_EC2_METADATA_DISABLED", "true");

            var client = new AmazonSecretsManagerClient(
                RegionEndpoint.GetBySystemName(region));

            var response = await client.GetSecretValueAsync(
                new GetSecretValueRequest
                {
                    SecretId = secretName
                });

            return response.SecretString!;
        }
    }
}

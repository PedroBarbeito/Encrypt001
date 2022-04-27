using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt001
{
    public class AuthenticationConfiguration
    {
        [JsonProperty("credentials")]
        public Collection<CredentialConfiguration> Credentials { get; set; }
    }
}

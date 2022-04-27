using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Encrypt001
{
    /// <summary>Represents a <see cref="ProtectedJsonConfigurationProvider"/> source</summary>
    public class ProtectedJsonConfigurationSource : JsonConfigurationSource
    {
        /// <summary>Gets the byte array to increse protection</summary>
        internal byte[] Entropy { get; private set; }

        /// <summary>Represents a <see cref="ProtectedJsonConfigurationProvider"/> source</summary>
        /// <param name="entropy">Byte array to increase protection</param>
        /// <exception cref="ArgumentNullException"/>
        public ProtectedJsonConfigurationSource(byte[] entropy)
        {
            this.Entropy = entropy ?? throw new ArgumentNullException(Localization.EntropyNotSpecifiedError);
        }

        /// <summary>Builds the configuration provider</summary>
        /// <param name="builder">Builder to build in</param>
        /// <returns>Returns the configuration provider</returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new ProtectedJsonConfigurationProvider(this);
        }

        /// <summary>Gets or sets the protection scope of the configuration provider. Default value is <see cref="DataProtectionScope.CurrentUser"/></summary>
        public DataProtectionScope Scope { get; set; }
        /// <summary>Gets or sets the regular expressions that must match the keys to encrypt</summary>
        public IEnumerable<Regex> EncryptedKeyExpressions { get; set; }
    }
}

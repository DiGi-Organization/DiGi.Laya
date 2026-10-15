namespace DiGi.Laya.Constants
{
    /// <summary>
    /// Provides the prefix of the embedded resource names the scripts are shipped under.
    /// </summary>
    public static class ResourcePrefix
    {
        /// <summary>
        /// The prefix of every script's resource name: the root namespace and the scripts folder, as the csproj's LogicalName "$(RootNamespace).Laya.%(Filename)%(Extension)" builds it.
        /// </summary>
        public const string Scripts = "DiGi.Laya.Laya.";
    }
}

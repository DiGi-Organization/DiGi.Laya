namespace DiGi.Laya.Constants
{
    /// <summary>
    /// Provides the names of the folders DiGi.Laya ships its scripts in and looks for.
    /// </summary>
    public static class DirectoryName
    {
        /// <summary>
        /// The folder the scripts are shipped in: files/Laya in the repository, Laya beside the built assembly, and the infix of their embedded resource names.
        /// </summary>
        public const string Laya = "Laya";

        /// <summary>
        /// The software destination DiGi.Maintenance's DeployLaya.ps1 deploys the Laya runtime package and released checkpoints to: &lt;SOFTWARE_DIRECTORY&gt;\DiGi.Laya\models\&lt;name&gt;.
        /// </summary>
        public const string DiGiLaya = "DiGi.Laya";

        /// <summary>
        /// The folder under Laya that deployed checkpoints live in; <see cref="Query.IsInsideModelsDirectory(string?)"/> keeps training outputs out of it.
        /// </summary>
        public const string Models = "models";
    }
}

namespace DiGi.Laya
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes every Laya script and requirements.txt into a directory, so that any one of them can be run from there.
        /// <para>Taken from the Laya folder beside the DiGi.Laya assembly when it is there - a script edited in a build output is then tried without rebuilding - and otherwise from the resources embedded in the assembly, so it works in a host that never copied the folder. Every file is rewritten on every call: a working directory outlives builds, and a script of an older build handed an argument it does not know would fail.</para>
        /// <para>All files are written together because each script imports utils.py, which Python resolves against the script's own directory, and check.py reads the laya pin from requirements.txt beside it.</para>
        /// </summary>
        /// <param name="directory">The directory to write the files into, created when missing.</param>
        /// <returns><c>true</c> when every file was written; otherwise <c>false</c>.</returns>
        public static bool WriteScripts(string? directory)
        {
            return Python.Modify.WriteScripts(typeof(Modify).Assembly, Constants.ResourcePrefix.Scripts, Constants.DirectoryName.Laya, [Constants.FileName.Utils, Constants.FileName.Check, Constants.FileName.Predict, Constants.FileName.Train, Constants.FileName.Calibrate, Constants.FileName.Requirements], directory);
        }
    }
}

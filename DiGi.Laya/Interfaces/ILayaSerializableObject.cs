namespace DiGi.Laya.Interfaces
{
    /// <summary>
    /// Marker interface implemented by every DiGi.Laya object that can be serialized to and from JSON.
    /// </summary>
    public interface ILayaSerializableObject : ILayaObject, Core.Interfaces.ISerializableObject
    {
    }
}

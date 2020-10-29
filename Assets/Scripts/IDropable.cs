using System;

/// <summary>
/// Implement this interface so that when the object is dropped into a DropReceiver, it will call the OnDrop method.
/// </summary>
public interface IDropable
{
    void OnDrop();
}
namespace UniBlog.Domain.Exceptions;

public class EntityNotFoundException(string type, int id) : Exception($"{type} with id {id} not found") { }
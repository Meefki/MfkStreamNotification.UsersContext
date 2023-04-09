﻿namespace Users.Domain.SeedWork;

public abstract class Entity<T>
{
    public Entity(EntityIdentifier<T> id)
    {
        _id = id.Value;
        _domainEvents = new();
    }

    int? _requestedHashCode;
    
    T _id;
    public virtual EntityIdentifier<T> Id
    {
        get
        {
            return new(_id);
        }
        protected set
        {
            _id = value.Value;
        }
    }

    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return Id == default;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Entity<T>))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        Entity<T> item = (Entity<T>)obj;

        if (item.IsTransient() || IsTransient())
            return false;
        else
            return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }

    public static bool operator ==(Entity<T> left, Entity<T> right)
    {
        if (Equals(left, null))
            return Equals(right, null) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !(left == right);
    }
}

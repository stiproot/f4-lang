namespace F4lang.Builder.Abstractions;

public interface ITypeMapper<TSource, TTarget>
{
	TTarget Map(TSource source);
}
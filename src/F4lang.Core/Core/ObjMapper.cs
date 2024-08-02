
using AutoMapper;

namespace F4lang.Core;

public sealed class ObjMapper(IMapper mapper) : IObjMapper
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public TTo Map<TFrom, TTo>(TFrom from) => this._mapper.Map<TFrom, TTo>(from);
}

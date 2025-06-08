using AutoMapper;
using MasterData.Application.Queries;
using MasterData.Application.Services;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public class ImportCertificateQueryHandler(IImportCertificateService importCertificateService, IMapper mapper) : IRequestHandler<ImportCertificateQuery, List<string>>
{
    private readonly IImportCertificateService _importCertificateService = importCertificateService;
    private readonly IMapper _mapper = mapper;

    public async Task<List<string>> Handle(ImportCertificateQuery request, CancellationToken cancellationToken)
    {
        var response = await _importCertificateService.GetInfoVisionApi(request.CvFile);
        return _mapper.Map<List<string>>(response);
    }
}

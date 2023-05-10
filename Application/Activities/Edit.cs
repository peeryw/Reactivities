using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Enity is now tracking activity
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                // going from an activity (object) and going to an activity (object)
                // takes all the properties from request and update the properties inside activity
                _mapper.Map(request.Activity, activity);

                // this is where the database gets updated
                await _context.SaveChangesAsync();

                // this basically returns nothing, but is required because of Task<Unit> type 
                // the return of nothing is used to let "us" know it is finished
                return Unit.Value;
            }
        }
    }
}
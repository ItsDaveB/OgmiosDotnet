# Project Close-out Report

## Name of Project and Project URL on IdeaScale/Fund

**Name:** OgmiosDotnet  
**URL:** [Project Catalyst URL](https://milestones.projectcatalyst.io/projects/1200163/milestones/1)

## Your Project Number

**Project Number:** 1200163

## Name of Project Manager

**Name:** Dave

## Date Project Started

**Start Date:** 12/08/2024

## Date Project Completed

**Completion Date:** 11/12/2024

## List of Challenge KPIs and How the Project Addressed Them

- **Challenge KPI 1:** Enhance .NET developers' access to Cardano blockchain.
  - Addressed by developing, open-sourcing and publishing OgmiosDotnet, a plug-and-play client library with seamless integration into .NET applications.
  - Included a Quick Start Worker application to demonstrate practical use cases and simplify adoption.
- **Challenge KPI 2:** Provide comprehensive tools and documentation for Cardano adoption in the .NET ecosystem.
  - Delivered detailed, modular documentation covering the client library and worker application setup, integration, and extensibility.
  - Published NuGet packages to ensure accessibility and encourage developer engagement.

## List of Project KPIs and How the Project Addressed Them

- **Project KPI 1:** Progressive reading of blockchain and memory pool data.
  - Implemented client functionality for slot-based blockchain data synchronization and real-time mempool transaction access.
- **Project KPI 2:** Ease of use and developer adoption.
  - Achieved with auto-generated idiomatic Ogmios schema types and Entity Framework Core for database integration.
  - Quick start example showcases seamless integration with PostgreSQL in-memory, encouraging practical application.

## Key Achievements

- Successfully developed and open-sourced OgmiosDotnet on GitHub.
- Published two NuGet packages:
  - [OgmiosDotnetClient.Services](https://www.nuget.org/packages/OgmiosDotnetClient.Services)
  - [OgmiosDotnetClient.Schema](https://www.nuget.org/packages/OgmiosDotnetClient.Schema)
- Enhanced .NET integration capabilities by enabling parallel processing for blockchain synchronization.
- Upgraded projects to .NET 9.0 for ~32% performance improvements.
- Collaborated with Demeter.Run to offer Ogmios as a service.
- Demonstrated practical blockchain usage via the Worker application, which includes database persistence.
- Introduced seamless dependency injection for Ogmios.Services:
  - Developers can integrate the services with a single line of code using the provided extension:
    ```csharp
    builder.Services.AddOgmiosServices();
    ```
  - This significantly reduces boilerplate code, promoting ease of use and rapid adoption.

## Key Learnings

- **Parallel processing:** Essential for improving blockchain synchronization efficiency, reducing the processing time of historical data.
- **Documentation importance:** Clear, modular documentation is crucial for developer adoption and open-source contributions.
- **Community collaboration:** Partnering with Demeter.Run provided valuable insights for scaling blockchain services.
- **Expanding language support:** Adding Ogmios support for new languages like .NET enhances Cardano’s global appeal.

## Next Steps for the Product or Service Developed

- Seek feedback from the .NET and Cardano communities for enhancements.
- Expand features to include transaction submission and ledger state querying.
- Consider integrating a React-based UI in the Worker application for visual demonstrations.
- Explore additional Catalyst funding to maintain parity with Ogmios and extend functionality.

## Final Thoughts/Comments

I am deeply grateful to the Catalyst community for funding this initiative. OgmiosDotnet has successfully addressed a critical gap in Cardano tooling for .NET developers, paving the way for broader blockchain adoption. Collaboration with the Demeter.Run team was invaluable, and I look forward to building on this momentum to further empower developers and enterprises within the Cardano ecosystem.

## Links to Demonstrations, Test Reports, and Other Relevant Project Sources

### **Video Demonstrations**

- [Memory Pool Monitoring Demo](https://www.youtube.com/watch?v=LvFKB3hGYXI): Showcases how OgmiosDotnet reads and monitors memory pool transactions.
- [Full Demonstration with Example Worker](https://youtu.be/vw6pFG0Q51s): Highlights chain synchronization, memory pool monitoring, and the Worker application in action.

### **Test Reports**

- [Test Report 1](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/reports/milestone-one/test-report.md): Covers milestone one for the implementation of the OgmiosDotnet Client.
- [Test Report 2](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/reports/milestone-two/test-report.md): Details milestone two for the memory pool monitoring implementation.
- [Test Report 3](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/reports/milestone-three/test-report.md): Verifies the final milestone for the Worker application and chain synchronization.

### **Other Resources**

- [GitHub Repository](https://github.com/ItsDaveB/OgmiosDotnet)
- Documentation:
  - [Worker Documentation README](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/docs/README.md)
  - [Main Project README](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/README.md)
  - [Ogmios.Schema Documentation README](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Schema/docs/README.md)
- NuGet Packages:
  - [OgmiosDotnetClient.Services](https://www.nuget.org/packages/OgmiosDotnetClient.Services)
  - [OgmiosDotnetClient.Schema](https://www.nuget.org/packages/OgmiosDotnetClient.Schema)

## License

The project is licensed under the permissive [MIT License](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/LICENSE), enabling others to freely use, modify, and distribute the software for both personal and commercial purposes.

## Link to Close-out Video

[YouTube/Vimeo Link](#)

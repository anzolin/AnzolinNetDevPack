<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

---


What is the AnzolinNetDevPack?
=====================

A smart set of common classes and implementations to improve your development productivity bundled in NuGet Packages.

See [my NuGet Profile](https://www.nuget.org/profiles/anzolin) to find more interesting packages.


Get Started
-----------
This nuget package can be installed using the Nuget package manager or the `dotnet` CLI.

```powershell
dotnet add package AnzolinNetDevPack
```


| Package             | Version                                                                                                         | Popularity                                                                                                       |
|---------------------|-----------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------|
| `AnzolinNetDevPack` | [![NuGet](https://img.shields.io/nuget/v/AnzolinNetDevPack)](https://www.nuget.org/packages/AnzolinNetDevPack/) | [![NuGet](https://img.shields.io/nuget/dt/AnzolinNetDevPack)](https://www.nuget.org/packages/AnzolinNetDevPack/) |


How it works
------------

| Class | Function | Parameters | Summary `pt-br` |
|---|---|---|---|
| **DateTimeHelper** | `GetDateTimeBrasilia` | N/A | Retorna a data/hora de agora de Brasília ("America/Sao_Paulo"). |
| **DateTimeHelper** | `GetDateTimeByTimeZone` | **string** windowsOrIanaTimeZoneId | Retorna a data/hora de agora de acordo com o timezone informado, exemplo: "America/Sao_Paulo". |
| **EnumHelper** | `GetValue` | **object** aEnum |  |
| **EnumHelper** | `GetText` | **object** aEnum |  |
| **EnumHelper** | `GetText` | **Type** aEnumType, **int** aKey |  |
| **EnumHelper** | `GetText` | **Type** aEnumType, **string** vEnumName |  |
| **EnumHelper** | `GetValueDisplayDictionary` | **Type** aEnumType |  |
| **EnumHelper** | `GetSelectListItems` | **Type** aEnumType, **int?** value |  |
| **SearchHelper** | `ApplyPaging` | **IEnumerable** enumerable, **int** count, **int** pageSize, **int?** page | Aplica uma paginação para o IEnumerable TModel. |
| **StringHelper** | `RemoveMask` | **string** value | Remove todos caracteres, deixando apenas letras e números. |
| **StringHelper** | `AddMask` | **MaskType** type, **string** value | Aplica a máscara escolhida. |
| **StringHelper** | `OnlyNumbers` | **string** value | Remove todas letras, deixando apenas números. |
| **TimeHelper** | `ConvertTime` | **string** time, **TimeHelper.Type** returnType | Converte uma string no formato "hh:mm:ss" para o tipo informado pelo parâmetro "returnType". |
| **TimeHelper** | `ConvertTime` | **string** time | Converte uma string no formato "hh:mm:ss" para um DateTime contendo a hora, em que o "dia", "mes" e "ano" são de um "DateTime.MinValue". |
| **TimeHelper** | `GetTimeAsString` | **double** time, **TimeHelper.Type** fromType | Obtêm uma hora no formato "hh:mm:ss" à partir tempo e tipo de tempo informados. |
| **TimeHelper** | `GetTimeAsArray` | **string** time | Obtêm uma hora como um array de 3 posições representando horas, minutos e segundos respectivamente, à partir tempo informado. Caso ocorra algum erro retorna nulo. |
| **TimeHelper** | `GetTime` | **DateTimeOffset** data | Retorna somente a informação de hora, minuto e segundo de uma data completa. |
| **TimeHelper** | `GetTime` | **DateTime** data | Retorna somente a informação de hora, minuto e segundo de uma data completa. |
| **TimeHelper** | `Truncate` | **DateTimeOffset** data |  |
| **CpfCnpjValidator** | `IsValid` | **string** cpfCnpj | Valida o documento informado. |
| **CpfCnpjValidator** | `IsCpf` | **string** cpf | Valida se é um CPF. |
| **CpfCnpjValidator** | `IsCnpj` | **string** cnpj | Valida se é CNPJ. |
| **EmailValidator** | `IsValidEmail` | **string** email | Valida se é um e-mail. |


Examples
-------

The sample application that uses the features will be available soon. In the meantime, explore the code to understand what it covers. 


License
-------

This NuGet Package is [MIT Licensed](https://github.com/anzolin/AnzolinNetDevPack/blob/master/LICENSE).


Give a Star! :star:
----------------------
If you liked the project or if NetDevPack helped you, please give a star ;)

  
About the author
----------------

Hello everyone, my name is Diego Anzolin Ferreira. I'm a .NET developer from Brazil. I hope you will enjoy this NuGet Package as much as I enjoy developing it. If you have any problems, you can post a [GitHub issue](https://github.com/anzolin/AnzolinNetDevPack/issues). You can reach me out at diego@anzolin.com.br.


Donate
------
  
Want to help me keep creating open source projects, make a donation:

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/donate?business=DN2VPNW42RTXY&no_recurring=0&currency_code=BRL)

Thank you!



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[contributors-url]: https://github.com/anzolin/AnzolinNetDevPack/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[forks-url]: https://github.com/anzolin/AnzolinNetDevPack/network/members
[stars-shield]: https://img.shields.io/github/stars/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[stars-url]: https://github.com/anzolin/AnzolinNetDevPack/stargazers
[issues-shield]: https://img.shields.io/github/issues/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[issues-url]: https://github.com/anzolin/AnzolinNetDevPack/issues
[license-shield]: https://img.shields.io/github/license/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[license-url]: https://github.com/anzolin/AnzolinNetDevPack/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/diego-anzolin/

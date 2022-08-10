<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Watchers][watchers-shield]][watchers-url]
[![Stargazers][stars-shield]][stars-url]
[![Forks][forks-shield]][forks-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

---

<!-- TABLE OF CONTENTS -->
### Table of Contents
<ol>
  <li><a href="#what-is">What is?</a></li>
  <li><a href="#installation">Installation</a></li>
  <li><a href="#how-it-works">How it works?</a></li>
  <li><a href="#examples">Examples</a></li>
  <li><a href="#how-can-i-contribute">How can I contribute?</a></li>
  <li><a href="#license">License</a></li>
  <li><a href="#about-the-author">About the author</a></li>
  <li><a href="#donate">Donate</a></li>
</ol>

---


## What is?

**AnzolinNetDevPack** is a NuGet Package that contains a group of help and validation classes that will help you in your ability to produce applications in an easier way.

| Current version | Downloads |
|---|---|
| [![NuGet](https://img.shields.io/nuget/v/AnzolinNetDevPack?style=for-the-badge)](https://www.nuget.org/packages/AnzolinNetDevPack/) | [![NuGet](https://img.shields.io/nuget/dt/AnzolinNetDevPack?style=for-the-badge)](https://www.nuget.org/packages/AnzolinNetDevPack/) |

This project is an update of [Anzolin.Net.NuGet](https://github.com/anzolin/Anzolin.Net.NuGet) which I decided to change the name, adjust a project pattern and also unify the nuget packages into a single package.

Also see [my NuGet Profile](https://www.nuget.org/profiles/anzolin) to find more interesting packages.


## Installation

Just add a dependency in your .csproj file to get the nuget:

```xml
<PackageReference Include="AnzolinNetDevPack" Version="1.2.0" />
```

Or from a command prompt:

```bash
dotnet add package AnzolinNetDevPack
```

```bash
Install-Package AnzolinNetDevPack
```


## How it works?

| Class | Function | Parameters | Summary `pt-br` | Summary `en-us` |
|---|---|---|---|---|
| **DateHelper** | `DateDiff` | **IntervalType** type, **DateTime** fromDate, **DateTime** toDate | Retorna entre datas de acordo com o tipo de intervalo escolhido. | |
| **DateTimeHelper** | `GetDateTimeBrasilia` | N/A | Retorna a data/hora de agora de Brasília ("America/Sao_Paulo"). |  |
| **DateTimeHelper** | `GetDateTimeByTimeZone` | **string** windowsOrIanaTimeZoneId | Retorna a data/hora de agora de acordo com o timezone informado, exemplo: "America/Sao_Paulo". |  |
| **EnumHelper** | `GetValue` | **object** aEnum | Retorna o valor inteiro do objeto enum informado. |  |
| **EnumHelper** | `GetText` | **object** aEnum | Retorna o valor texto do objeto enum informado. |  |
| **EnumHelper** | `GetText` | **Type** aEnumType, **int** aKey | Retorna o valor texto do objeto enum informado. |  |
| **EnumHelper** | `GetText` | **Type** aEnumType, **string** vEnumName | Retorna o valor texto do objeto enum informado. |  |
| **EnumHelper** | `GetValueDisplayDictionary` | **Type** aEnumType | Retorna um dicionário do tipo int, string do objeto enum informado. |  |
| **EnumHelper** | `GetSelectListItems` | **Type** aEnumType, **int?** value | Retorna uma lista do tipo SelectListItem do objeto enum informado. Para ser utilizado em lookups. |  |
| **HangfireForMySqlHelper** | `Enqueue` | **Expression** methodCall | Enfilera um trabalho. |  |
| **HangfireForMySqlHelper** | `GetJobDetails` | **MySqlStorage** storage, **string** jobId | Retorna os detalhes do trabalho informado. |  |
| **HangfireForMySqlHelper** | `GetJobResult` | **MySqlStorage** storage, **string** jobId | Retorna o resultado da execução do trabalho informado. |  |
| **HangfireForSqlServerHelper** | `Enqueue` | **Expression** methodCall | Enfilera um trabalho. |  |
| **HangfireForSqlServerHelper** | `GetJobDetails` | **SqlServerStorage** storage, **string** jobId | Retorna os detalhes do trabalho informado. |  |
| **HangfireForSqlServerHelper** | `GetJobResult` | **SqlServerStorage** storage, **string** jobId | Retorna o resultado da execução do trabalho informado. |  |
| **SearchHelper** | `ApplyPaging` | **IEnumerable** enumerable, **int** count, **int** pageSize, **int?** page | Aplica uma paginação para o IEnumerable TModel. |  |
| **StringHelper** | `RemoveMask` | **string** value | Remove todos caracteres, deixando apenas letras e números. |  |
| **StringHelper** | `AddMask` | **MaskType** type, **string** value | Aplica a máscara escolhida. |  |
| **StringHelper** | `OnlyNumbers` | **string** value | Remove todas letras, deixando apenas números. |  |
| **StringHelper** | `FirstChatToUpper` | **string** value | Aplica o primeiro caracter da string como maiúsculo. | |
| **StringHelper** | `RemoveAccents` | **string** value | Remove acentuações. | |
| **StringHelper** | `SizeSuffix` | **string** value, **int** decimalPlaces | Converte e formata um número em tamanho de arquivo. | |
| **TimeHelper** | `ConvertTime` | **string** time, **TimeHelper.Type** returnType | Converte uma string no formato "hh:mm:ss" para o tipo informado pelo parâmetro "returnType". |  |
| **TimeHelper** | `ConvertTime` | **string** time | Converte uma string no formato "hh:mm:ss" para um DateTime contendo a hora, em que o "dia", "mes" e "ano" são de um "DateTime.MinValue". |  |
| **TimeHelper** | `GetTimeAsString` | **double** time, **TimeHelper.Type** fromType | Obtêm uma hora no formato "hh:mm:ss" à partir tempo e tipo de tempo informados. |  |
| **TimeHelper** | `GetTimeAsArray` | **string** time | Obtêm uma hora como um array de 3 posições representando horas, minutos e segundos respectivamente, à partir tempo informado. Caso ocorra algum erro retorna nulo. |  |
| **TimeHelper** | `GetTime` | **DateTimeOffset** data | Retorna somente a informação de hora, minuto e segundo de uma data completa. |  |
| **TimeHelper** | `GetTime` | **DateTime** data | Retorna somente a informação de hora, minuto e segundo de uma data completa. |  |
| **TimeHelper** | `Truncate` | **DateTimeOffset** data | Retorna a data e hora completa, sendo o tempo absoluto. |  |
| **CpfCnpjValidator** | `IsValid` | **string** cpfCnpj | Valida o documento informado. |  |
| **CpfCnpjValidator** | `IsCpf` | **string** cpf | Valida se é um CPF. |  |
| **CpfCnpjValidator** | `IsCnpj` | **string** cnpj | Valida se é CNPJ. |  |
| **EmailValidator** | `IsValidEmail` | **string** email | Valida se é um e-mail. |  |
| **Services** | `ConsultaCnpj` | **string** cnpj | Consulta os dados da pessoa jurídica através do Cnpj informado. |  |
| **Services** | `ConsultaCnpjAsync` | **string** cnpj | Consulta os dados da pessoa jurídica através do Cnpj informado. |  |


## Examples

The application containing all the examples is under development but you can find some of them.

I recommend that you explore the code to understand what it covers, it's easy to realize.


## How can I contribute?

If you want to help the project, improving it or creating something new, welcome. This project was created to be a home of useful and reusable pieces of code for the .NET community. So if you have any code snippet that is useful, clean, decoupled and tested, and want to contribute to this goal, please make a [pull request](https://github.com/anzolin/AnzolinNetDevPack/pulls)!


## License

This project is [MIT Licensed](https://github.com/anzolin/AnzolinNetDevPack/blob/master/LICENSE).

  
## About the author

Hello everyone, my name is Diego Anzolin Ferreira. I'm a .NET developer from Brazil. I hope you will enjoy this project as much as I enjoy developing it. If you have any problems, you can post a [GitHub issue](https://github.com/anzolin/AnzolinNetDevPack/issues). You can reach me out at diego@anzolin.com.br.


## Donate
  
Want to help me keep creating open source projects, make a donation:

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg?style=for-the-badge)](https://www.paypal.com/donate?business=DN2VPNW42RTXY&no_recurring=0&currency_code=BRL) [![Donate](https://img.shields.io/badge/-buy_me_a%C2%A0coffee-gray?logo=buy-me-a-coffee&style=for-the-badge)](https://www.buymeacoffee.com/anzolin)

Thank you!



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[contributors-url]: https://github.com/anzolin/AnzolinNetDevPack/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[forks-url]: https://github.com/anzolin/AnzolinNetDevPack/network/members
[watchers-shield]: https://img.shields.io/github/watchers/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[watchers-url]: https://github.com/anzolin/AnzolinNetDevPack/watchers
[stars-shield]: https://img.shields.io/github/stars/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[stars-url]: https://github.com/anzolin/AnzolinNetDevPack/stargazers
[issues-shield]: https://img.shields.io/github/issues/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[issues-url]: https://github.com/anzolin/AnzolinNetDevPack/issues
[license-shield]: https://img.shields.io/github/license/anzolin/AnzolinNetDevPack.svg?style=for-the-badge
[license-url]: https://github.com/anzolin/AnzolinNetDevPack/blob/master/LICENSE.txt

# General description:
- The program takes 2 arguments: 
	1. Input path (mandatory), full path including file name and extension
	2. Output path (optional), full path including file name and extension

- If output path is not specified, input path will be used to generate output.
- The program does not generate directory on demand, please create all necessary path in advance.

# Output result:
- By default, the program add "-clean" on the output file regardless of whether 2nd argument is provided or not.

# How to: Build the project
- Clone the project
- Update all packages
- Build

#How to: Run a release build
- To run a release build, type below command in command prompt:
- > outliers.exe [input path] [output path]

# Sample run:
> F:\Users\Nick\Desktop\interview\executable>outliers.exe F:\Users\Nick\Desktop\interview\instruction\Outliers.csv F:\Users\Nick\Desktop\interview\Outliers-Output.csv
>
> [13/8/2018 0:59:47] Loading from F:\Users\Nick\Desktop\interview\instruction\Outliers.csv

> [13/8/2018 0:59:47] Processing data set

> [13/8/2018 0:59:47] Dumping data to F:\Users\Nick\Desktop\interview\Outliers-Output-clean.csv

> [13/8/2018 0:59:47] Completed. Details:

>
> Loaded Count:1000

> Validated Count:992

> Outliers:

> Date:30/1/1990 0:00:00 Price:110.9257881 IntradayPriceReturn:0.0978345589117949

> Date:31/1/1990 0:00:00 Price:100.6396907 IntradayPriceReturn:-0.0927295408595794

> Date:12/7/1990 0:00:00 Price:124.855201 IntradayPriceReturn:0.191921069942467

> Date:13/7/1990 0:00:00 Price:104.9008922 IntradayPriceReturn:-0.159819604150891

> Date:14/7/1992 0:00:00 Price:133.3289493 IntradayPriceReturn:0.114788893377335

> Date:10/11/1992 0:00:00 Price:123.8835704 IntradayPriceReturn:-0.0718141314404458

> Date:11/11/1992 0:00:00 Price:133.9379917 IntradayPriceReturn:0.0811602480259158

> Date:17/3/1993 0:00:00 Price:155.8201696 IntradayPriceReturn:0.107271721695488

> Press any key to close...
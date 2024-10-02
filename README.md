# ColorSpace.Net

**ColorSpace.Net** is a comprehensive .NET library designed for converting between various color spaces. It simplifies color space transformations, making color management tasks more intuitive and efficient for developers.

## Features

- Straightforward conversion between multiple color spaces.
- Supports a wide range of color spaces (see list below).
- Customizable illuminant options for precise color transformations.

## Installation

You can install `ColorSpace.Net` via NuGet or by cloning the repository directly. Choose one of the following methods:

### Option 1: Install via NuGet

#### NuGet Package Manager

To install using the **NuGet Package Manager Console**, use the following command:

```bash
Install-Package ColorSpace.Net
```

#### .NET CLI

Alternatively, you can install the package using the **.NET CLI**:

```bash
dotnet add package ColorSpace.Net
```

### Option 2: Clone the Repository

You can also clone the repository directly and build the project locally:

1. Open a terminal and navigate to the directory where you want to clone the project.
2. Run the following command to clone the repository:

```bash
git clone https://github.com/your-username/ColorSpace.Net.git
```

3. Navigate into the cloned directory:

```bash
cd ColorSpace.Net
```

4. Build the project:

```bash
dotnet build
```

5. You can now reference this project in your .NET solution or use it as part of your development environment.

## Supported Color Spaces

ColorSpace.Net currently supports conversions between the following color spaces:

- CMY (Cyan, Magenta, Yellow)
- CMYK (Cyan, Magenta, Yellow, Black)
- HSL (Hue, Saturation, Lightness)
- HSV (Hue, Saturation, Value)
- CIE L*AB (CIELAB)
- Hunter LAB
- LCH (Lightness, Chroma, Hue)
- LUV
- RGB (Red, Green, Blue)
- XYZ (CIE 1931)
- YXY (Yxy Color Model)

## Getting Started

Below is a simple example demonstrating how to use **ColorSpace.Net** for color conversion.

### Example: Convert RGB to CMYK

```csharp
using ColorSpace.Net;
using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert;
using System;

namespace ColorSpace.Net.Example
{
    public class ColorConversionExample
    {
        public static void Main()
        {
            // Create a converter to convert RGB to CMYK
            IColorConverter<Cmyk> converter = ConverterBuilder.Create(new ColorConverterOptions() 
                                                                      { Illuminant = Illuminants.D65_2 })
                                                              .ToColor<Cmyk>()
                                                              .Build();

            // Define an RGB color
            Rgb rgb = Rgb.FromRgb(49, 125, 96);

            // Convert RGB to CMYK
            Cmyk cmyk = converter.ConvertFrom<Rgb>(rgb);

            // Output the result
            Console.WriteLine($"CMYK: {cmyk}");
        }
    }
}
```

In this example:
- We define an RGB color using specific values.
- The RGB color is converted to the CMYK color space using the `ColorSpace.Net` library.
- The example uses the D65 illuminant with a 2° observer for the color conversion, but this can be customized as needed.

## Contributing

We welcome contributions! To contribute to **ColorSpace.Net**, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with your changes.

We encourage you to check the issue tracker for open discussions or features that may need attention.

## License

**ColorSpace.Net** is licensed under the MIT License. For more information, see the [LICENSE](LICENSE.txt) file.

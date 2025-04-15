using System.Text.Json;
using ComeForBrains.Core.GameWorld;

namespace ComeForBrains.Core.Building.GameWorld;

public class TextFileMapBuilder : IMapBuilder
{
    public TextFileMapBuilder(string pathToData)
    {
        mapDataProvider = new FromTextFileMapDataProvider(
            Path.Combine(pathToData, "Map.txt")
        );
        tileDescriptorsDataProvieder = new FromFileJsonProvider(
            Path.Combine(pathToData, "Tiles.json")
        );
    }
    public TextFileMapBuilder(
        IMapDataProvider mapDataProvider,
        IJsonProvider tileDescriptorsDataProvieder
    )
    {
        this.mapDataProvider = mapDataProvider;
        this.tileDescriptorsDataProvieder = tileDescriptorsDataProvieder;
    }

    public void Build()
    {
        TileDescriptor[] tileDescriptors = ReadTileDescriptors();
        AssignDescriptorsBySymbols(tileDescriptors);

        var mapData = mapDataProvider.GetMapData();
        BuildTiles(mapData);
        width = tiles[0].Length;
        height = tiles.Length;

        built = true;
    }

    private void BuildTiles(string[] mapData)
    {
        tiles = new Tile[mapData.Length][];
        for (int lineIndex = 0; lineIndex < mapData.Length; lineIndex++)
            BuildLineOfTiles(mapData, lineIndex);
    }

    private void BuildLineOfTiles(string[] mapData, int lineIndex)
    {
        string line = mapData[lineIndex];
        tiles[lineIndex] = new Tile[line.Length];
        for (int charIndex = 0; charIndex < line.Length; charIndex++)
        {
            CheckDescriptorExistence(line, charIndex);

            tiles[lineIndex][charIndex] = new Tile(
                tdBySymbol[line[charIndex]].Name,
                tdBySymbol[line[charIndex]].Description,
                tdBySymbol[line[charIndex]].Passability
            );
        }
    }

    private void CheckDescriptorExistence(string line, int charIndex)
    {
        if (!tdBySymbol.ContainsKey(line[charIndex]))
        {
            throw new InvalidOperationException(
                $"No tile descriptor found for symbol \"{line[charIndex]}\""
            );
        }
    }

    private void AssignDescriptorsBySymbols(TileDescriptor[] tileDescriptors)
    {
        tdBySymbol = new Dictionary<char, TileDescriptor>();
        foreach (var td in tileDescriptors)
            tdBySymbol.Add(td.Symbol[0], td);
    }

    private TileDescriptor[] ReadTileDescriptors()
    {
        var options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        };

        var tileDescriptors = JsonSerializer.Deserialize<TileDescriptor[]>(
            tileDescriptorsDataProvieder.GetJson(), options
        );
        if (tileDescriptors is null)
            throw new InvalidOperationException("No tile descriptors found");
        return tileDescriptors;
    }

    public int GetHeight()
    {
        if(!built)
        {
            throw new InvalidOperationException(
                "Cannot get height of non-built map"
            );
        }

        return height;
    }

    public Tile GetTile(int line, int column)
    {
        if(!built)
        {
            throw new InvalidOperationException(
                "Cannot get tile of non-built map"
            );
        }

        return tiles[line][column];
    }

    public int GetWidth()
    {
        if(!built)
        {
            throw new InvalidOperationException(
                "Cannot get width of non-built map"
            );
        }

        return width;
    }


    private sealed class TileDescriptor
    {
        public string Symbol { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Passability { get; set; } = 0;
    }
    
    private int width = 0;
    private int height = 0;
    private bool built = false;
    Tile[][] tiles = null!;
    private Dictionary<char, TileDescriptor> tdBySymbol = null!;

    private readonly IMapDataProvider mapDataProvider;
    private readonly IJsonProvider tileDescriptorsDataProvieder;
}

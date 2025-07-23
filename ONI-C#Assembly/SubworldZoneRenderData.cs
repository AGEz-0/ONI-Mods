// Decompiled with JetBrains decompiler
// Type: SubworldZoneRenderData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Delaunay.Geo;
using Klei;
using ProcGen;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SubworldZoneRenderData")]
public class SubworldZoneRenderData : KMonoBehaviour
{
  [SerializeField]
  private Texture2D colourTex;
  [SerializeField]
  private Texture2D indexTex;
  [HideInInspector]
  public SubWorld.ZoneType[] worldZoneTypes;
  [SerializeField]
  [HideInInspector]
  public Color32[] zoneColours = new Color32[18]
  {
    new Color32((byte) 145, (byte) 198, (byte) 213, (byte) 0),
    new Color32((byte) 135, (byte) 82, (byte) 160 /*0xA0*/, (byte) 1),
    new Color32((byte) 123, (byte) 151, (byte) 75, (byte) 2),
    new Color32((byte) 236, (byte) 189, (byte) 89, (byte) 3),
    new Color32((byte) 201, (byte) 152, (byte) 181, (byte) 4),
    new Color32((byte) 222, (byte) 90, (byte) 59, (byte) 5),
    new Color32((byte) 201, (byte) 152, (byte) 181, (byte) 6),
    new Color32(byte.MaxValue, (byte) 0, (byte) 0, (byte) 7),
    new Color32((byte) 201, (byte) 201, (byte) 151, (byte) 8),
    new Color32((byte) 236, (byte) 90, (byte) 110, (byte) 9),
    new Color32((byte) 110, (byte) 236, (byte) 110, (byte) 10),
    new Color32((byte) 145, (byte) 198, (byte) 213, (byte) 11),
    new Color32((byte) 145, (byte) 198, (byte) 213, (byte) 12),
    new Color32((byte) 145, (byte) 198, (byte) 213, (byte) 13),
    new Color32((byte) 173, (byte) 222, (byte) 212, (byte) 14),
    new Color32((byte) 100, (byte) 100, (byte) 222, (byte) 18),
    new Color32((byte) 222, (byte) 100, (byte) 222, (byte) 19),
    new Color32((byte) 100, (byte) 222, (byte) 100, (byte) 20)
  };
  private const int NUM_COLOUR_BYTES = 3;
  public int[] zoneTextureArrayIndices = new int[24]
  {
    0,
    1,
    2,
    3,
    4,
    5,
    5,
    3,
    6,
    7,
    8,
    9,
    10,
    11,
    12,
    7,
    3,
    13,
    0,
    0,
    0,
    14,
    15,
    16 /*0x10*/
  };

  protected override void OnSpawn()
  {
    base.OnSpawn();
    ShaderReloader.Register(new System.Action(this.OnShadersReloaded));
    this.GenerateTexture();
    this.OnActiveWorldChanged();
    Game.Instance.Subscribe(1983128072, (Action<object>) (worlds => this.OnActiveWorldChanged()));
  }

  public void OnActiveWorldChanged()
  {
    byte[] rawTextureData1 = this.colourTex.GetRawTextureData();
    byte[] rawTextureData2 = this.indexTex.GetRawTextureData();
    WorldDetailSave clusterDetailSave = SaveLoader.Instance.clusterDetailSave;
    Vector2 zero = Vector2.zero;
    for (int index = 0; index < clusterDetailSave.overworldCells.Count; ++index)
    {
      WorldDetailSave.OverworldCell overworldCell = clusterDetailSave.overworldCells[index];
      Polygon poly = overworldCell.poly;
      ref Vector2 local1 = ref zero;
      UnityEngine.Rect bounds = poly.bounds;
      double num1 = (double) (int) Mathf.Floor(bounds.yMin);
      local1.y = (float) num1;
      while (true)
      {
        double y = (double) zero.y;
        bounds = poly.bounds;
        double num2 = (double) Mathf.Ceil(bounds.yMax);
        if (y < num2)
        {
          ref Vector2 local2 = ref zero;
          bounds = poly.bounds;
          double num3 = (double) (int) Mathf.Floor(bounds.xMin);
          local2.x = (float) num3;
          while (true)
          {
            double x = (double) zero.x;
            bounds = poly.bounds;
            double num4 = (double) Mathf.Ceil(bounds.xMax);
            if (x < num4)
            {
              if (poly.Contains(zero))
              {
                int cell = Grid.XYToCell((int) zero.x, (int) zero.y);
                if (Grid.IsValidCell(cell))
                {
                  if (Grid.IsActiveWorld(cell))
                  {
                    rawTextureData2[cell] = overworldCell.zoneType == SubWorld.ZoneType.Space ? byte.MaxValue : (byte) this.zoneTextureArrayIndices[(int) overworldCell.zoneType];
                    Color32 zoneColour = this.zoneColours[(int) overworldCell.zoneType];
                    rawTextureData1[cell * 3] = zoneColour.r;
                    rawTextureData1[cell * 3 + 1] = zoneColour.g;
                    rawTextureData1[cell * 3 + 2] = zoneColour.b;
                  }
                  else
                  {
                    rawTextureData2[cell] = byte.MaxValue;
                    Color32 zoneColour = this.zoneColours[7];
                    rawTextureData1[cell * 3] = zoneColour.r;
                    rawTextureData1[cell * 3 + 1] = zoneColour.g;
                    rawTextureData1[cell * 3 + 2] = zoneColour.b;
                  }
                }
              }
              ++zero.x;
            }
            else
              break;
          }
          ++zero.y;
        }
        else
          break;
      }
    }
    this.colourTex.LoadRawTextureData(rawTextureData1);
    this.indexTex.LoadRawTextureData(rawTextureData2);
    this.colourTex.Apply();
    this.indexTex.Apply();
    this.OnShadersReloaded();
  }

  public void GenerateTexture()
  {
    byte[] numArray = new byte[Grid.WidthInCells * Grid.HeightInCells];
    byte[] data = new byte[Grid.WidthInCells * Grid.HeightInCells * 3];
    this.worldZoneTypes = new SubWorld.ZoneType[Grid.CellCount];
    this.colourTex = new Texture2D(Grid.WidthInCells, Grid.HeightInCells, TextureFormat.RGB24, false);
    this.colourTex.name = "SubworldRegionColourData";
    this.colourTex.filterMode = FilterMode.Bilinear;
    this.colourTex.wrapMode = TextureWrapMode.Clamp;
    this.colourTex.anisoLevel = 0;
    this.indexTex = new Texture2D(Grid.WidthInCells, Grid.HeightInCells, TextureFormat.Alpha8, false);
    this.indexTex.name = "SubworldRegionIndexData";
    this.indexTex.filterMode = FilterMode.Point;
    this.indexTex.wrapMode = TextureWrapMode.Clamp;
    this.indexTex.anisoLevel = 0;
    for (int index = 0; index < Grid.CellCount; ++index)
    {
      numArray[index] = byte.MaxValue;
      Color32 zoneColour = this.zoneColours[7];
      data[index * 3] = zoneColour.r;
      data[index * 3 + 1] = zoneColour.g;
      data[index * 3 + 2] = zoneColour.b;
      this.worldZoneTypes[index] = SubWorld.ZoneType.Space;
    }
    this.colourTex.LoadRawTextureData(data);
    this.indexTex.LoadRawTextureData(numArray);
    this.colourTex.Apply();
    this.indexTex.Apply();
    WorldDetailSave clusterDetailSave = SaveLoader.Instance.clusterDetailSave;
    Vector2 zero = Vector2.zero;
    for (int index = 0; index < clusterDetailSave.overworldCells.Count; ++index)
    {
      WorldDetailSave.OverworldCell overworldCell = clusterDetailSave.overworldCells[index];
      Polygon poly = overworldCell.poly;
      ref Vector2 local1 = ref zero;
      UnityEngine.Rect bounds = poly.bounds;
      double num1 = (double) (int) Mathf.Floor(bounds.yMin);
      local1.y = (float) num1;
      while (true)
      {
        double y = (double) zero.y;
        bounds = poly.bounds;
        double num2 = (double) Mathf.Ceil(bounds.yMax);
        if (y < num2)
        {
          ref Vector2 local2 = ref zero;
          bounds = poly.bounds;
          double num3 = (double) (int) Mathf.Floor(bounds.xMin);
          local2.x = (float) num3;
          while (true)
          {
            double x = (double) zero.x;
            bounds = poly.bounds;
            double num4 = (double) Mathf.Ceil(bounds.xMax);
            if (x < num4)
            {
              if (poly.Contains(zero))
              {
                int cell = Grid.XYToCell((int) zero.x, (int) zero.y);
                if (Grid.IsValidCell(cell))
                {
                  numArray[cell] = overworldCell.zoneType == SubWorld.ZoneType.Space ? byte.MaxValue : (byte) overworldCell.zoneType;
                  this.worldZoneTypes[cell] = overworldCell.zoneType;
                }
              }
              ++zero.x;
            }
            else
              break;
          }
          ++zero.y;
        }
        else
          break;
      }
    }
    this.InitSimZones(numArray);
  }

  private void OnShadersReloaded()
  {
    Shader.SetGlobalTexture("_WorldZoneTex", (Texture) this.colourTex);
    Shader.SetGlobalTexture("_WorldZoneIndexTex", (Texture) this.indexTex);
  }

  public SubWorld.ZoneType GetSubWorldZoneType(int cell)
  {
    return cell >= 0 && cell < this.worldZoneTypes.Length ? this.worldZoneTypes[cell] : SubWorld.ZoneType.Sandstone;
  }

  private unsafe void InitSimZones(byte[] bytes)
  {
    fixed (byte* msg = bytes)
      Sim.SIM_HandleMessage(-457308393, bytes.Length, msg);
  }
}

// Decompiled with JetBrains decompiler
// Type: Database.BalloonOverrideSymbol
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public readonly struct BalloonOverrideSymbol
{
  public readonly Option<KAnim.Build.Symbol> symbol;
  public readonly Option<KAnimFile> animFile;
  public readonly string animFileID;
  public readonly string animFileSymbolID;

  public unsafe BalloonOverrideSymbol(string animFileID, string animFileSymbolID)
  {
    if (string.IsNullOrEmpty(animFileID) || string.IsNullOrEmpty(animFileSymbolID))
    {
      *(BalloonOverrideSymbol*) ref this = new BalloonOverrideSymbol();
    }
    else
    {
      this.animFileID = animFileID;
      this.animFileSymbolID = animFileSymbolID;
      this.animFile = (Option<KAnimFile>) Assets.GetAnim((HashedString) animFileID);
      this.symbol = (Option<KAnim.Build.Symbol>) this.animFile.Value.GetData().build.GetSymbol((KAnimHashedString) animFileSymbolID);
    }
  }

  public void ApplyTo(BalloonArtist.Instance artist) => artist.SetBalloonSymbolOverride(this);

  public void ApplyTo(BalloonFX.Instance balloon) => balloon.SetBalloonSymbolOverride(this);
}

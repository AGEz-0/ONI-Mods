// Decompiled with JetBrains decompiler
// Type: Database.StickerBombs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class StickerBombs : ResourceSet<DbStickerBomb>
{
  public StickerBombs(ResourceSet parent)
    : base(nameof (StickerBombs), parent)
  {
    foreach (StickerBombFacadeInfo stickerBombFacade in Blueprints.Get().all.stickerBombFacades)
      this.Add(stickerBombFacade.id, stickerBombFacade.name, stickerBombFacade.desc, stickerBombFacade.rarity, stickerBombFacade.animFile, stickerBombFacade.sticker, stickerBombFacade.requiredDlcIds, stickerBombFacade.GetForbiddenDlcIds());
  }

  private DbStickerBomb Add(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animfilename,
    string symbolName,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds)
  {
    DbStickerBomb dbStickerBomb = new DbStickerBomb(id, name, desc, rarity, animfilename, symbolName, requiredDlcIds, forbiddenDlcIds);
    this.resources.Add(dbStickerBomb);
    return dbStickerBomb;
  }

  public DbStickerBomb GetRandomSticker() => this.resources.GetRandom<DbStickerBomb>();
}

using Exiled.API.Interfaces;
using System.ComponentModel;

namespace StartUtilis
{
    public class Config : IConfig
    {
        [Description("Enable or Disable the plugin?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Не используется.")]
        public bool Debug { get; set; } = false;
        [Description("Turn on the broadcast to the player who logged on to the server?")]
        public bool IsJoinBroadcast { get; set; } = true;
        [Description("Broadcast to the player who logged on to the server.")]
        public string JoinBroadcast { get; set; } = "<color=yellow>Приветствуем <color=red>%nick%</color> на сервере</color>\n<b>*Название*</b>";
        [Description("Включить урон по своим в конце раунда?")]
        public bool IsFriendlyFire { get; set; } = true;
        [Description("При включенном уроне по своим сколько снимать с игрока хп?")]
        public int HitAmount { get; set; } = 70;
        [Description("Включить размьют игрока, который зашёл на сервер?")]
        public bool IsUnmute { get; set; } = true;
        [Description("Включить бесконечный радио?")]
        public bool IsInfiniteRadio { get; set; } = true;
        [Description("Включить текст, если посмотреть на скромника? (ломается, если включить MtfTag)")]
        public bool IsTriggerScp { get; set; } = true;
        [Description("Текст, если посмотреть на скромника.")]
        public string TriggerHint { get; set; } = "<color=red>Внимание:</color>\n<color=#8b00ff>Вы посмотрели на <color=red>Скромника</color>!</color>";
        [Description("Убрать возможность игрокам выбрасывать патроны? (они будут падать, если игрок умрет)")]
        public bool IsAllowDropAmmo { get; set; } = true;
        [Description("Включить бесконечные патроны? (каждый патрон возвращается обратно)")]
        public bool IsInfiniteAmmo { get; set; } = true;
        [Description("Включить выдачу патронов при спавне игрока?")]
        public bool IsGiveAmmo { get; set; } = true;
        [Description("Количество патронов, которое нужно дать игроку при спавне.")]
        public ushort GiveAmmo { get; set; } = 100;
        [Description("При смерти Сцп писать всеобщий бродкаст?")]
        public bool IsScpBroadcast { get; set; } = true;
        [Description("Всеобщий бродкаст при смерти SCP объета.")]
        public string ScpBroadcast { get; set; } = "<color=#FF0000>{scpRole} {scp}</color> <color=yellow>был убит игроком</color> <color=#30d5c8>{attacker}";
        [Description("Сколько секунд показывать всеобщий бродкаст?")]
        public ushort ScpBroadcastTime { get; set; } = 7;
        [Description("Полезная фича. Выключить в начале раунда заблокированный раунд и лобби? (+ выкл заблок боеголовку)")]
        public bool IsDisableLock { get; set; } = true;
    }
}

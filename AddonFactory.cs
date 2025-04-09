
using OOPConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class AddonFactory
    {
        public Addon CreateAddon(string name)
        {
            Addon addon;
            switch (name)
            {
                case "기본 상호작용 드론": addon = new Addon("기본 상호작용 드론", AddonType.Interaction, AddonGrade.Basic, "외계인의 말을 일부 해석할 수 있다."); break;
                case "외계 기술 드론": addon = new Addon("외계 기술 드론", AddonType.Interaction, AddonGrade.AlienTech, "외계인의 말을 전부 해석할 수 있다."); break;
                case "기본 연료 포집 드론": addon = new Addon("기본 연료 포집 드론", AddonType.Fuel, AddonGrade.Basic, "연료 획득 시 1개의 ＊당 1의 연료를 획득할 수 있다."); break;
                case "외계 기술 연료 포집 드론": addon = new Addon("외계 기술 연료 포집 드론", AddonType.Fuel, AddonGrade.AlienTech, "연료 획득 시 1개의 ＊당 3의 연료를 획득할 수 있다."); break;
                case "기본 산소 포집 드론": addon = new Addon("기본 산소 포집 드론", AddonType.Oxygen, AddonGrade.Basic, "산소 획득 시 1개의 ＆ 당 1의 산소를 획득할 수 있다."); break;
                case "외계 기술 산소 포집 드론": addon = new Addon("외계 기술 산소 포집 드론", AddonType.Oxygen, AddonGrade.AlienTech, "산소 획득 시 1개의 ＆ 당 3의 산소를 획득할 수 있다."); break;
                case "기본 레이더": addon = new Addon("기본 레이더", AddonType.Radar, AddonGrade.Basic, "내 주위 근방 1칸의 은하에 대한 정보 열람이 가능하다."); break;
                case "외계 기술 레이더": addon = new Addon("외계 기술 레이더", AddonType.Radar, AddonGrade.AlienTech, "모든 은하에 대한 정보 열람이 가능하다."); break;
                default: return null;
            }

            return addon;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void StorePlayerLocation(GameObject player)
    {
        PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);
        PlayerPrefs.SetFloat("PlayerRotX", player.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("PlayerRotY", player.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("PlayerRotZ", player.transform.rotation.eulerAngles.z);
    }

    // Stores wether a planet is discovered or not, so that it doesn't appear as "Unknown Planet" if the game is loaded.
    public static void StorePlanetStatuses(List<GameObject> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i].GetComponent<PlanetScript>().discovered)
            {
                PlayerPrefs.SetInt(planets[i].name + "Discovered", 1);
            }
            else
            {
                PlayerPrefs.SetInt(planets[i].name + "Discovered", 0);
            }
        }
    }

    public static void StorePlanetLocations(List<GameObject> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            PlayerPrefs.SetFloat(planets[i].name + "PosX", planets[i].transform.position.x);
            PlayerPrefs.SetFloat(planets[i].name + "PosY", planets[i].transform.position.y);
            PlayerPrefs.SetFloat(planets[i].name + "PosZ", planets[i].transform.position.z);
            PlayerPrefs.SetFloat(planets[i].name + "RotX", planets[i].transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat(planets[i].name + "RotY", planets[i].transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat(planets[i].name + "RotZ", planets[i].transform.rotation.eulerAngles.z);
        }
    }

    public static void StoreCameraFOV()
    {
        PlayerPrefs.SetFloat("CameraFOV", Camera.main.fieldOfView);
    }

    public static void LoadPlayerLocation(GameObject player)
    {
        if (PlayerPrefsManager.HasPlayerLocationKeys())
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            player.transform.position = new Vector3(x, y, z);
            x = PlayerPrefs.GetFloat("PlayerRotX");
            y = PlayerPrefs.GetFloat("PlayerRotY");
            z = PlayerPrefs.GetFloat("PlayerRotZ");
            player.transform.rotation = Quaternion.Euler(x, y, z);
        }
    }

    public static void LoadPlanetsStatuses(List<GameObject> planets)
    {
        if (PlayerPrefsManager.HasPlanetStatusesKeys(planets))
        {
            for (int i = 0; i < planets.Count; i++)
            {
                if (PlayerPrefs.GetInt(planets[i].name + "Discovered") == 1)
                {
                    planets[i].GetComponent<PlanetScript>().discovered = true;
                }
                else
                {
                    planets[i].GetComponent<PlanetScript>().discovered = false;
                }
            }
        }
    }

    public static void LoadPlanetsLocations(List<GameObject> planets)
    {
        if (PlayerPrefsManager.HasPlanetLocationsKeys(planets))
        {
            for (int i = 0; i < planets.Count; i++)
            {
                float x = PlayerPrefs.GetFloat(planets[i].name + "PosX");
                float y = PlayerPrefs.GetFloat(planets[i].name + "PosY");
                float z = PlayerPrefs.GetFloat(planets[i].name + "PosZ");
                planets[i].transform.position = new Vector3(x, y, z);
                x = PlayerPrefs.GetFloat(planets[i].name + "RotX");
                y = PlayerPrefs.GetFloat(planets[i].name + "RotY");
                z = PlayerPrefs.GetFloat(planets[i].name + "RotZ");
                planets[i].transform.rotation = Quaternion.Euler(x,y,z);
            }
        }
    }

    public static void LoadCameraFOV()
    {
        float fov = PlayerPrefs.GetFloat("CameraFOV");
        Camera.main.fieldOfView = fov;
    }

    private static bool HasPlayerLocationKeys()
    {
        if (
            PlayerPrefs.HasKey("PlayerPosX") ||
            PlayerPrefs.HasKey("PlayerPosY") ||
            PlayerPrefs.HasKey("PlayerPosZ") ||
            PlayerPrefs.HasKey("PlayerRotX") ||
            PlayerPrefs.HasKey("PlayerRotY") ||
            PlayerPrefs.HasKey("PlayerRotZ")
            )
        {
            return true;
        }
        return false;
    }

    private static bool HasPlanetStatusesKeys(List<GameObject> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (!PlayerPrefs.HasKey(planets[i].name + "Discovered"))
            {
                Debug.Log("PlayerPref Key \"" + planets[i].name + "Discovered\" was not found.");
                return false;
            }
        }
        return true;
    }

    private static bool HasPlanetLocationsKeys(List<GameObject> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (
                !PlayerPrefs.HasKey(planets[i].name + "PosX") ||
                !PlayerPrefs.HasKey(planets[i].name + "PosY") ||
                !PlayerPrefs.HasKey(planets[i].name + "PosZ") ||
                !PlayerPrefs.HasKey(planets[i].name + "RotX") ||
                !PlayerPrefs.HasKey(planets[i].name + "RotY") ||
                !PlayerPrefs.HasKey(planets[i].name + "RotZ")
                )
            {
                Debug.Log("PlayerPref Key \"" + planets[i].name + "Pos/RotXYZ\" was not found.");
                return false;
            }
        }
        return true;
    }
}

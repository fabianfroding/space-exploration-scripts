using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void StorePlayerLocation(GameObject player)
    {
        PlayerPrefs.SetFloat("PlayerPositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", player.transform.position.z);
        PlayerPrefs.SetFloat("PlayerRotationX", player.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("PlayerRotationY", player.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("PlayerRotationZ", player.transform.rotation.eulerAngles.z);
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
            PlayerPrefs.SetFloat(planets[i].name + "PositionX", planets[i].transform.position.x);
            PlayerPrefs.SetFloat(planets[i].name + "PositionY", planets[i].transform.position.y);
            PlayerPrefs.SetFloat(planets[i].name + "PositionZ", planets[i].transform.position.z);
            PlayerPrefs.SetFloat(planets[i].name + "RotationX", planets[i].transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat(planets[i].name + "RotationY", planets[i].transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat(planets[i].name + "RotationZ", planets[i].transform.rotation.eulerAngles.z);
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
            float x = PlayerPrefs.GetFloat("PlayerPositionX");
            float y = PlayerPrefs.GetFloat("PlayerPositionY");
            float z = PlayerPrefs.GetFloat("PlayerPositionZ");
            player.transform.position = new Vector3(x, y, z);
            x = PlayerPrefs.GetFloat("PlayerRotationX");
            y = PlayerPrefs.GetFloat("PlayerRotationY");
            z = PlayerPrefs.GetFloat("PlayerRotationZ");
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
                float x = PlayerPrefs.GetFloat(planets[i].name + "PositionX");
                float y = PlayerPrefs.GetFloat(planets[i].name + "PositionY");
                float z = PlayerPrefs.GetFloat(planets[i].name + "PositionZ");
                planets[i].transform.position = new Vector3(x, y, z);
                x = PlayerPrefs.GetFloat(planets[i].name + "RotationX");
                y = PlayerPrefs.GetFloat(planets[i].name + "RotationY");
                z = PlayerPrefs.GetFloat(planets[i].name + "RotationZ");
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
            PlayerPrefs.HasKey("PlayerPositionX") ||
            PlayerPrefs.HasKey("PlayerPositionY") ||
            PlayerPrefs.HasKey("PlayerPositionZ") ||
            PlayerPrefs.HasKey("PlayerRotationX") ||
            PlayerPrefs.HasKey("PlayerRotationY") ||
            PlayerPrefs.HasKey("PlayerRotationZ")
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
                !PlayerPrefs.HasKey(planets[i].name + "LocationX") ||
                !PlayerPrefs.HasKey(planets[i].name + "LocationY") ||
                !PlayerPrefs.HasKey(planets[i].name + "LocationZ") ||
                !PlayerPrefs.HasKey(planets[i].name + "RotationX") ||
                !PlayerPrefs.HasKey(planets[i].name + "RotationY") ||
                !PlayerPrefs.HasKey(planets[i].name + "RotationZ")
                )
            {
                Debug.Log("PlayerPref Key \"" + planets[i].name + "Location/RotationXYZ\" was not found.");
                return false;
            }
        }
        return true;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlasticIdentifier.Objects;
using System.Web;
using System.Data.Entity;

namespace PlasticIdentifier.Helpers
{
    public class ImageHelper
    {
        private static readonly string APP_DATA = @"~/Images/";

        /*
         * This function will ensure that the images file
         * is always accessible to the solution, no matter
         * on which system it is currently running.
         * 
         * IN: n/a
         * OUT: the path to the Images folder
         */ 

        public static string getStorageFolder()
        {
            try
            {
                bool app_dataExists = Directory.Exists(APP_DATA);
                if (!app_dataExists)
                {
                    Directory.CreateDirectory(APP_DATA);
                }
                return APP_DATA;
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.ToString()));
                return null;
            }
        }

        /*
         * This will add images specified in a directory
         * to a given DataSet in_dataset. Once the images
         * have compelted adding, it will copy the files
         * to a local file
         * 
         * IN: 
         *  - file_path (Type: string): the path of the file directory
         *      that contains the images to be added to the set 
         *  - in_dataset (Type: DataSet): the dataset to which the 
         *      images has to be added.
         */

        public static void addImagesToSet(string file_path, DataSet in_dataset)
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(file_path);

                List<Image> new_list = new List<Image>();

                foreach (string fileName in fileEntries)
                {

                    FileInfo file = new FileInfo(fileName);

                    if (file.Extension != ".jpg")
                    {
                        continue;
                    }

                    new_list.Add(new Image
                    {
                        FileLocation = file.FullName,
                        ImageSize = file.Length / 6,
                        DataSetId = in_dataset.Id,
                        IsPlastic = false
                    });
                }
                using (var db = new PlasticDBContext())
                {
                    in_dataset.Images = new_list;

                    db.Images.AddRange(new_list);

                    db.SaveChanges();
                }

                copyToLocal(in_dataset);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        /*
         * This will determine whether a image is in 
         * a local file.
         * 
         * IN: in_image (Type: Image) - The image to be checked
         * OUT:
         *  - Returns true if the image is in a local folder
         *      relative to the solution.
         *  - Returns false if the image is not in a local
         *      folder relative to the solution.
         */

        public bool isImageLocal(Image in_img)
        {

            try
            {
                return scanDirectory(getStorageFolder(), in_img);
            }
            catch (Exception ex)
            {
                return false;
            }          
        }

        /*
         * This is a helper function for isImageLocal.
         * This function will recursevily iterate over
         * the image directory to determine if the image
         * can be located in a local file relative
         * to the solution.
         * 
         * IN: 
         *  - directory (Type: string): the directory to be iterated over
         *  - in_img (Type: Image): the image that is being searched for.
         *  
         *  OUT: 
         *   - true if the image exists
         *   - false if the image does not exist
         */
        public bool scanDirectory(string directory, Image in_img)
        {
            bool exists = false;

            try
            {
                string[] fileEntries = Directory.GetFiles(directory);
                foreach (string fileName in fileEntries)
                {
                    if (in_img.Id.ToString() == fileName)
                    {
                        return true;
                    }
                }

                string[] subdirectoryEntries = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    scanDirectory(subdirectory, in_img);
                }
                return exists;
            }
            catch (Exception ex)
            {
                return exists;
            }
        }

        /*
         * This function will copy images
         * from a created dataset to a local file.
         * 
         * The function will try and create a driectory
         * for a dataset based on the Id or the Name, depending
         * on which is available.
         * 
         * IN: in_set (Type: DataSet) - this contatins the images to be copied
         * OUT: 
         *  - Returns false if unsuccesful
         *  - Returns true if successful
         */
         
        public static bool copyToLocal(DataSet in_set)
        {
            try
            {
                string to_directory;
                if (!String.IsNullOrEmpty(in_set.Name))
                {
                    to_directory = getStorageFolder() + "/" + in_set.Name + "_" + in_set.Id;
                    Directory.CreateDirectory(to_directory);
                }
                else
                {
                    to_directory = getStorageFolder() + "/DataSet_" + in_set.Id;
                    Directory.CreateDirectory(to_directory);
                }

                foreach (var img in in_set.Images)
                {
                    try
                    {
                        File.SetAttributes(img.FileLocation, File.GetAttributes(img.FileLocation) & ~FileAttributes.ReadOnly);
                        File.SetAttributes(APP_DATA, File.GetAttributes(APP_DATA) & ~FileAttributes.ReadOnly);
                        FileInfo file = new FileInfo(img.FileLocation);
                        File.Copy(img.FileLocation, Path.Combine(to_directory, file.Name), true);
                    }
                    catch (IOException ioex)
                    {
                        Console.WriteLine(ioex.Message);
                        return false;
                    }
                }

                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
    
}
